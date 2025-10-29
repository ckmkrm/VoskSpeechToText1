using Microsoft.VisualBasic.ApplicationServices;
using NAudio.Wave;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
using Vosk;

namespace VoskSpeechToText1
{
    public partial class Form1 : Form
    {
        private WaveInEvent? waveIn;
        private VoskRecognizer? recognizer;
        private Model? model;

        public Form1()
        {
            InitializeComponent();
            btnStart.Click += btnStart_Click!;
            btnStop.Click += btnStop_Click!;
        }

        private void LoadModel()
        {
            if (model == null)
            {
                string modelPath = "C:\\Users\\lenovo-pc\\Downloads\\vosk-model-small-tr-0.3\\vosk-model-small-tr-0.3"; // model yolunu kendine g�re d�zelt
                model = new Model(modelPath);
                recognizer = new VoskRecognizer(model, 16000.0f);
            }
        }

        private void btnStart_Click(object? sender, EventArgs e)
        {
            txtOutput.Clear();
            txtOutput.AppendText("Kay�t ba�lat�l�yor, l�tfen bekleyin...\r\n");

            try
            {
                LoadModel();

                if (WaveInEvent.DeviceCount == 0)
                    throw new Exception("Hi� mikrofon cihaz� bulunamad�.");

                waveIn = new WaveInEvent
                {
                    DeviceNumber = 0,
                    WaveFormat = new WaveFormat(16000, 1)
                };
                waveIn.DataAvailable += WaveIn_DataAvailable!;
                waveIn.StartRecording();

                txtOutput.AppendText("Kay�t ba�lad�.\r\n");
            }
            catch (Exception ex)
            {
                txtOutput.AppendText("Hata: " + ex.Message + "\r\n");
            }
        }

        private void btnStop_Click(object? sender, EventArgs e)
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
                waveIn.Dispose();
                waveIn = null;
                txtOutput.AppendText("Kay�t durduruldu.\r\n");
            }
        }

       
            private string lastText = ""; // Son yazd�r�lan metin

        private void WaveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            if (recognizer == null) return;

            try
            {
                if (recognizer.AcceptWaveform(e.Buffer, e.BytesRecorded))
                {
                    // Tam metin
                    var result = JObject.Parse(recognizer.Result());
                    var text = result["text"]?.ToString() ?? "";

                    // �nceki ile ayn�ysa tekrar yazd�rma
                    if (!string.IsNullOrWhiteSpace(text) && text != lastText)
                    {
                        lastText = text;
                        Invoke(() => txtOutput.Text = text); // TextBox'a tek seferlik yaz
                    }
                }
                else
                {
                    // Partial metin
                    var partial = JObject.Parse(recognizer.PartialResult())["partial"]?.ToString() ?? "";

                    // Son tam metin ile ayn�ysa yazma
                    if (!string.IsNullOrWhiteSpace(partial) && partial != lastText)
                    {
                        Invoke(() => txtOutput.Text = partial);
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke(() => txtOutput.AppendText("Hata: " + ex.Message + "\r\n"));
            }
        }

        

        private void txtOutput_TextChanged(object? sender, EventArgs e)
        {
            // Tasar�mda ba�l�ysa hata vermesin
        }
    }
}
