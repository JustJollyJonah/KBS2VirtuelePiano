using KBS2VirtuelePiano.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace KBS2VirtuelePiano.Model
{
    public class Song
    {

        // TODO: Private maken
        [Browsable(false)]
        public List<Measure> Measures;
        [Browsable(false)]
        public int SongID { get; set; }
        public string Author { get; set; }
        public int Level { get; set; }  
        public string Name { get; set; }
        [Browsable(false)]
        public int BeatsPerMinute { get; set; }
        [Browsable(false)]
        public int BeatsPerMeasure { get; set; }
        [Browsable(false)]
        public ComponentLength BeatLength { get; set; }

        // MeasureLength is het aantal nieuwe noten die HORIZONTAAL
        // in een nieuwe Measure mogen staan.
        [Browsable(false)]
        public int MeasureLength {
            get
            {
                return BeatsPerMeasure * (int) BeatLength;
            }
        }

        public Song() : this(4, 4, 60) { }

        public Song(int beatsPerMeasure, int beatLength) : this(beatsPerMeasure, beatLength, 60) { }

        public Song(int beatsPerMeasure, int beatLength, int bpm)
        {
            // 4, 2 => 4 * 0.5 = 2 hele noot = 2 * ComponentLength.FULL = 32
            Measures = new List<Measure>();
            BeatsPerMeasure = beatsPerMeasure;
            BeatLength = (ComponentLength)((int) ComponentLength.FULL / beatLength);
            BeatsPerMinute = bpm;
        }

        public List<SongComponent> GetSongComponentsAtX(int x)
        {
            int xPerMeasure = GetXPerMeasure();
            int restant = x % xPerMeasure;
            int measureNummer = (int)Math.Floor(((double)x) / (double)xPerMeasure);

            return Measures[measureNummer].GetComponentsAt(restant);
        }

        public int GetXPerMeasure()
        {
            // -- VOORBEELD: new Song(4, 2);

            // BeatsPerMeasure = 4;
            // BeatLength (= 2) = ComponentLength.HALF = 8;

            // componentLengthFrac = 8 / 16 (ComponentLength.FULL) = 0.5;
            // measureLength = 4 * 0.5 = 2;
            // smallestComponentLength = 1 / 16 (ComponentLength.FULL) = 0.0625
            
            // xPerMeasure = measureLength / smallestComponentLength = 2 / 0.0625 (1/16) = 32 (x-per-measure);

            double componentLengthFrac = ((double)BeatLength) / (double)ComponentLength.FULL;
            double measureLength = (double)BeatsPerMeasure * componentLengthFrac;
            double smallestComponentLength = 1d / (int)ComponentLength.FULL;

            return (int) (measureLength / smallestComponentLength);
        }

        public double GetMillisecondsPerX(int bpm)
        {
            return ((60d / bpm) * 1000d) / (double) GetXPerMeasure();
        }

        public void AutoGenerate()
        {
            ComponentLength compLen = ComponentLength.FULL; // 8 out of 16

            int octaveX = 7 * (int)compLen;
            int totalX = Piano.OCTAVEN * octaveX;
            int measures = (int)Math.Ceiling(((double)totalX) / (double)ComponentLength.FULL);
            int notesPerMeasure = ((int)ComponentLength.FULL) / (int)compLen;

            int oct = 0;
            int note = 0;

            for (int m = 0; m < measures; m++)
            {
                Measure measure = new Measure();
                for (int n = 0; n < notesPerMeasure; n++)
                {
                    measure.Components.Add(new Note(
                        (NoteLetter)note++,
                        Piano.BASE_OCTAAF + Piano.OCTAVEN - (oct + 1),
                        true,
                        compLen,
                        n * (int)compLen
                    ));
                    //measure.Components.Add(new Rest(compLen, n * (int)compLen));
                    if (note == 7)
                    {
                        note = 0;
                        oct++;

                        if (oct >= Piano.OCTAVEN)
                            break;
                    }
                }
                Measures.Add(measure);
            }
        }
    }
}