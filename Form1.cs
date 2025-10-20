using System.IO.Ports;
using System.Text;
using YamlDotNet.Serialization;

namespace GeniSerialTest
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private SerialConfig? serialConfig;
        private readonly object lockObject = new object();

        // 수신 버퍼 관리를 위한 필드들 추가
        private List<byte> receiveBuffer = new List<byte>();
        private System.Windows.Forms.Timer bufferTimer;
        private const int BUFFER_TIMEOUT_MS = 100; // 100ms 타임아웃
        private int maxReceiveBytes = 0; // config.yaml에서 가장 큰 수신 데이터 크기

        public Form1()
        {
            InitializeComponent();
            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived;

            // 버퍼 타이머 초기화
            bufferTimer = new System.Windows.Forms.Timer();
            bufferTimer.Interval = BUFFER_TIMEOUT_MS;
            bufferTimer.Tick += BufferTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 시리얼 포트 목록 로드
            LoadSerialPorts();

            // 기본값 설정
            SetDefaultValues();

            // YAML 설정 파일 로드
            LoadConfigFile();
        }

        private void LoadSerialPorts()
        {
            comboBoxPortName.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBoxPortName.Items.Add(port);
            }
            if (comboBoxPortName.Items.Count > 0)
                comboBoxPortName.SelectedIndex = 0;
        }

        private void SetDefaultValues()
        {
            comboBoxBaudRate.SelectedItem = "9600";
            comboBoxDataBits.SelectedItem = "8";
            comboBoxStopBits.SelectedItem = "One";
            comboBoxParity.SelectedItem = "None";
        }

        private void LoadConfigFile()
        {
            try
            {
                string configPath = Path.Combine(Application.StartupPath, "config.yaml");
                if (File.Exists(configPath))
                {
                    string yamlContent = File.ReadAllText(configPath);
                    var deserializer = new DeserializerBuilder().Build();
                    serialConfig = deserializer.Deserialize<SerialConfig>(yamlContent);

                    // config.yaml에서 가장 큰 수신 데이터 크기 계산
                    CalculateMaxReceiveBytes();

                    LogMessage("설정 파일을 로드했습니다: " + configPath, false);
                    LogMessage($"총 {serialConfig?.Commands?.Count ?? 0}개의 명령이 로드되었습니다.", false);
                    LogMessage($"최대 수신 바이트 크기: {maxReceiveBytes}바이트", false);
                }
                else
                {
                    LogMessage("설정 파일을 찾을 수 없습니다: " + configPath, false);
                }
            }
            catch (Exception ex)
            {
                LogMessage("설정 파일 로드 오류: " + ex.Message, false);
            }
        }

        private void CalculateMaxReceiveBytes()
        {
            maxReceiveBytes = 0;
            if (serialConfig?.Commands != null)
            {
                foreach (var command in serialConfig.Commands)
                {
                    try
                    {
                        // YAML에서 받은 16진수 문자열을 바이트 배열로 변환하여 크기 계산
                        byte[] receiveBytes = HexStringToBytes(command.Receive);
                        if (receiveBytes.Length > maxReceiveBytes)
                        {
                            maxReceiveBytes = receiveBytes.Length;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"명령 크기 계산 오류 ({command.Receive}): {ex.Message}", false);
                    }
                }
            }

            // 최소 1바이트는 보장
            if (maxReceiveBytes == 0)
                maxReceiveBytes = 1;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPortName.SelectedItem == null)
                {
                    MessageBox.Show("포트를 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                serialPort.PortName = comboBoxPortName.SelectedItem.ToString()!;
                serialPort.BaudRate = int.Parse(comboBoxBaudRate.SelectedItem?.ToString() ?? "9600");
                serialPort.DataBits = int.Parse(comboBoxDataBits.SelectedItem?.ToString() ?? "8");
                serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopBits.SelectedItem?.ToString() ?? "One");
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxParity.SelectedItem?.ToString() ?? "None");

                serialPort.Open();

                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
                labelStatus.Text = "상태: 연결됨 (" + serialPort.PortName + ")";

                LogMessage("시리얼 포트가 연결되었습니다.", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("연결 실패: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }

                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
                labelStatus.Text = "상태: 연결안됨";

                LogMessage("시리얼 포트 연결이 해제되었습니다.", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("연결 해제 실패: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // 바이트 데이터로 수신
                int bytesToRead = serialPort.BytesToRead;
                if (bytesToRead == 0) return;

                byte[] buffer = new byte[bytesToRead];
                serialPort.Read(buffer, 0, bytesToRead);

                lock (lockObject)
                {
                    // 수신 버퍼에 데이터 추가
                    receiveBuffer.AddRange(buffer);

                    // 최대 바이트 수를 초과하면 버퍼 무효화
                    if (receiveBuffer.Count > maxReceiveBytes)
                    {
                        this.Invoke(new Action(() =>
                        {
                            LogMessage($"버퍼 크기 초과로 무효화: 현재 {receiveBuffer.Count}바이트 > 최대 {maxReceiveBytes}바이트", true);
                            LogMessage($"무효화된 데이터: {BytesToHexString(receiveBuffer.ToArray())}", true);
                        }));

                        receiveBuffer.Clear();
                        bufferTimer.Stop();
                        return;
                    }

                    // 타이머 재시작 (새 데이터가 올 때마다 타이머 리셋)
                    this.Invoke(new Action(() =>
                    {
                        bufferTimer.Stop();
                        bufferTimer.Start();

                        // 실시간 수신 로그 (부분 데이터)
                        string hexString = BytesToHexString(buffer);
                        LogMessage($"수신 (부분): {hexString} [버퍼크기: {receiveBuffer.Count}/{maxReceiveBytes}]", true);
                    }));
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    LogMessage("데이터 수신 오류: " + ex.Message, true);
                }));
            }
        }

        private string BytesToHexString(byte[] bytes)
        {
            return string.Join(" ", bytes.Select(b => b.ToString("X2")));
        }

        private void BufferTimer_Tick(object? sender, EventArgs e)
        {
            bufferTimer.Stop();

            lock (lockObject)
            {
                if (receiveBuffer.Count > 0)
                {
                    // 완전한 데이터로 간주하고 처리
                    byte[] completeData = receiveBuffer.ToArray();
                    receiveBuffer.Clear();

                    string hexString = BytesToHexString(completeData);
                    LogMessage($"수신 (완료): {hexString}", true);
                    ProcessReceivedData(completeData);
                }
            }
        }

        private byte[] HexStringToBytes(string hexString)
        {
            // 공백 제거 및 대문자 변환
            hexString = hexString.Replace(" ", "").ToUpper();

            if (hexString.Length % 2 != 0)
                throw new ArgumentException("16진수 문자열의 길이가 올바르지 않습니다.");

            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return bytes;
        }

        private void ProcessReceivedData(byte[] receivedData)
        {
            lock (lockObject)
            {
                if (serialConfig?.Commands != null)
                {
                    string receivedHex = BytesToHexString(receivedData);

                    foreach (var command in serialConfig.Commands)
                    {
                        try
                        {
                            // YAML에서 받은 16진수 문자열을 바이트 배열로 변환
                            byte[] expectedBytes = HexStringToBytes(command.Receive);

                            // 바이트 배열 비교
                            if (ByteArraysEqual(receivedData, expectedBytes))
                            {
                                // 응답 데이터를 바이트 배열로 변환하여 전송
                                byte[] responseBytes = HexStringToBytes(command.Send);
                                SendResponse(responseBytes, command.Description);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            LogMessage($"명령 처리 오류 ({command.Receive}): {ex.Message}", false);
                        }
                    }
                }

                // 매칭되는 명령이 없는 경우
                LogMessage("알 수 없는 명령: " + BytesToHexString(receivedData), false);
            }
        }

        private bool ByteArraysEqual(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length) return false;
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i]) return false;
            }
            return true;
        }

        private void SendResponse(byte[] responseBytes, string description)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Write(responseBytes, 0, responseBytes.Length);
                    string hexString = BytesToHexString(responseBytes);
                    LogMessage($"송신: {hexString} ({description})", false);
                }
            }
            catch (Exception ex)
            {
                LogMessage("데이터 송신 오류: " + ex.Message, false);
            }
        }

        private void LogMessage(string message, bool isReceived)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
            string logMessage = $"[{timestamp}] {message}\r\n";

            if (isReceived)
            {
                textBoxReceived.AppendText(logMessage);
                textBoxReceived.ScrollToCaret();
            }
            else
            {
                textBoxSent.AppendText(logMessage);
                textBoxSent.ScrollToCaret();
            }
        }

        private void buttonLoadConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "YAML files (*.yaml)|*.yaml|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string yamlContent = File.ReadAllText(openFileDialog.FileName);
                    var deserializer = new DeserializerBuilder().Build();
                    serialConfig = deserializer.Deserialize<SerialConfig>(yamlContent);

                    // config.yaml에서 가장 큰 수신 데이터 크기 계산
                    CalculateMaxReceiveBytes();

                    LogMessage("설정 파일을 로드했습니다: " + openFileDialog.FileName, false);
                    LogMessage($"총 {serialConfig?.Commands?.Count ?? 0}개의 명령이 로드되었습니다.", false);
                    LogMessage($"최대 수신 바이트 크기: {maxReceiveBytes}바이트", false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("설정 파일 로드 오류: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClearReceived_Click(object sender, EventArgs e)
        {
            textBoxReceived.Clear();
        }

        private void buttonClearSent_Click(object sender, EventArgs e)
        {
            textBoxSent.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bufferTimer?.Stop();
                bufferTimer?.Dispose();

                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                serialPort.Dispose();
            }
            catch (Exception ex)
            {
                // 폼 종료 시 오류는 무시
                System.Diagnostics.Debug.WriteLine("Form closing error: " + ex.Message);
            }
        }
    }
}
