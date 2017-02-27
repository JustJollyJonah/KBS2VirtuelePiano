using KBS2VirtuelePiano.Model;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Helper
{
    public static class SoundHelper
    {

        private static bool initialized = false;
        public static MixingWaveProvider32 mixingWaveProvider = new MixingWaveProvider32();
        public static IWavePlayer outputDevice = new WaveOutEvent();
        public static List<SineWaveProvider32> WaveList = new List<SineWaveProvider32>();
        public static bool soundStatus = false;
        
        //Initializeert de Output.
        public static void InitializeOutput()
        {
            if (initialized)
                return;

            initialized = true;
            outputDevice.Init(mixingWaveProvider);
            outputDevice.Play();
        }
        //Voor het afspelen van een geluid 
        public static void PlaySound(SineWaveProvider32 wave)
        {
            WaveList.Add(wave); //Geluid wordt toegevoegd aan de lijst met huidige items in de queue.
            mixingWaveProvider.AddInputStream(WaveList.LastOrDefault()); //Meest recente Item wordt toegevoegd aan de mixer
            outputDevice.Play(); //Speelt geluid af.
        }
        public static void StopNote(Note note)
        {
            var result = WaveList.Where(x => x.Frequency == (float)note.GetFrequencyInHz()); //Pakt de SineWaveProvider uit de lijst.
            foreach(SineWaveProvider32 i in result) { 
                mixingWaveProvider.RemoveInputStream(i); //Verwijdert de SineWave uit de mixer.
                
            }
            WaveList.Remove(result.FirstOrDefault());//Verwijdert de resultaten van de bovenstaand query.


        }
        //Cleart de lijst met Waves en gooit de Mixer weg en herinstatieert hem.
        public static void StopAll()
        {
            outputDevice.Stop();

            mixingWaveProvider = null;
            mixingWaveProvider = new MixingWaveProvider32();
            WaveList.Clear();
            Cleanup();
          
        }
        //Voorkomt het voorkomen van audio-artifacts bij snel afspelen van dingen.
        public static void Cleanup()
        {
            outputDevice.Dispose();
            outputDevice = null;
            outputDevice = new WaveOutEvent();
            outputDevice.Init(mixingWaveProvider);
        }
        
    }
}
