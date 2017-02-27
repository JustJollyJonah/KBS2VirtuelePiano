using KBS2VirtuelePiano.Controller;
using KBS2VirtuelePiano.Model;
using KBS2VirtuelePiano.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Helper
{
    public static class Renderer
    {
        // Brushes, pennen en font
        public static readonly Brush BRUSH = new SolidBrush(Color.Black);
        public static readonly Brush BRUSH_DEBUG = new SolidBrush(Color.Red);
        public static readonly Brush BRUSH_PROGRESS = new SolidBrush(Color.FromArgb(130, 177, 255));
        public static readonly Brush BRUSH_BACKGROUND = new SolidBrush(Color.White);

        public static readonly Brush BRUSH_RED = new SolidBrush(Color.FromArgb(155, 255, 0, 0));
        public static readonly Brush BRUSH_GREEN = new SolidBrush(Color.FromArgb(155, 0, 255, 0));
        public static readonly Brush BRUSH_BLUE = new SolidBrush(Color.FromArgb(155, 0, 0, 255));
        public static readonly Brush BRUSH_ORANGE = new SolidBrush(Color.FromArgb(155, 255, 140, 0));
        public static readonly Brush BRUSH_PURPLE = new SolidBrush(Color.FromArgb(155, 255, 0, 255));

        public static readonly Pen PEN = new Pen(BRUSH, 1.0f);
        public static readonly Pen PEN_TOPLINE = new Pen(BRUSH, 4.0f);
        public static readonly Pen PEN_DEBUG = new Pen(BRUSH_DEBUG, 3.0f);
        public static readonly Pen PEN_PROGRESS = new Pen(BRUSH_PROGRESS, 3.0f);
        public static readonly Pen PEN_PIANO = new Pen(BRUSH, PIANO_LINE_WIDTH);

        public static readonly Pen PEN_RED = new Pen(BRUSH_RED, 1.0f);
        public static readonly Pen PEN_BLUE = new Pen(BRUSH_GREEN, 1.0f);
        public static readonly Pen Pen_GREEN = new Pen(BRUSH_BLUE, 1.0f);

        public static readonly Font FONT = new Font("Arial", 14);
        public static readonly StringFormat STRING_FORMAT = GetCenteredStringFormat();
        private static Rectangle RECT = new Rectangle(0, 0, 0, 0);

        // Afbeeldingen
        // Noten
        public static readonly Image IMAGE_G_KEY = Properties.Resources.gKey;
        public static readonly Image IMAGE_NOTE_EIGHT_FLAG = Properties.Resources.AchsteNoot_vlaggetje;
        // Noten Ondersteboven
        public static readonly Image IMAGE_NOTE_EIGHT_FLAG_FLIP = Properties.Resources.AchsteNoot_vlaggetje_flip;
        // Rusten
        public static readonly Image IMAGE_REST_FULL = Properties.Resources.REST_FULL_HALF;
        public static readonly Image IMAGE_REST_HALF = Properties.Resources.REST_FULL_HALF;
        public static readonly Image IMAGE_REST_QAURTER = Properties.Resources.RestQuarter;
        public static readonly Image IMAGE_REST_EIGHT = Properties.Resources.RestEighth;
        public static readonly Image IMAGE_REST_SIXTEETH = Properties.Resources.RestSixteenth;
        // Bes
        public static readonly Image IMAGE_NOTE_BES = Properties.Resources.Note_Bes;
        public static readonly Image IMAGE_NOTE_HASHTAG = Properties.Resources.Note_HASHTAG;

        // Menu balk offset
        public static readonly int OFFSET_X = 0;
        public static readonly int OFFSET_Y = 40; // hoogte van menubalk.

        // Hoogte van één Y coördinaat
        public static readonly int LINE_PADDING_VERTICAL = 6;
        public static readonly int LINE_COUNT = 5;

        // G-Sleutel breedte + paddings
        public static readonly int G_KEY_PADDING_PRE = OFFSET_X + 10;
        public static readonly int G_KEY_WIDTH = 19; //IMAGE_G_KEY.Width;
        public static readonly int G_KEY_PADDING_POST = 10;
        public static readonly int G_KEY_TOTAL_WIDTH =
            G_KEY_PADDING_PRE +
            G_KEY_WIDTH +
            G_KEY_PADDING_POST;

        // Tijdsignatuur breedte + padding
        public static readonly int TIME_SIGNATURE_PADDING_PRE = 0;
        public static readonly int TIME_SIGNATURE_WIDTH = 0;
        public static readonly int TIME_SIGNATURE_PADDING_POST = 0;
        public static readonly int TIME_SIGNATURE_TOTAL_WIDTH =
            TIME_SIGNATURE_PADDING_PRE +
            TIME_SIGNATURE_WIDTH +
            TIME_SIGNATURE_PADDING_POST;

        // Padding die boven en onder een row komt te staan
        public static readonly int ROW_PADDING_COUNT = 5;
        public static readonly int ROW_PADDING_VERTICAL =
            ROW_PADDING_COUNT * LINE_PADDING_VERTICAL;

        // Hoogte van één row exclusief de onderste padding.
        // We doen -1 omdat we niet de lijnen tellen maar de ruimte er TUSSEN.
        public static readonly int ROW_HEIGHT =
            LINE_PADDING_VERTICAL * (LINE_COUNT - 1) * 2;

        // Hoogte van één row inclusief de onderste padding
        public static readonly int ROW_TOTAL_HEIGHT =
            ROW_PADDING_VERTICAL +
            ROW_HEIGHT +
            ROW_PADDING_VERTICAL;

        // Totale breedte van een measure
        public static readonly int MEASURE_BAR_WIDTH = 1;
        public static readonly int MEASURE_WIDTH = 10 + MEASURE_BAR_WIDTH; // TODO

        // Padding en breedte van een noot (incl. vlaggetjes)
        public static readonly int NOTE_RENDER_PADDING = 13;
        public static readonly int NOTE_PADDING = 10;
        public static readonly int NOTE_WIDTH_PRE = 16;
        public static readonly int NOTE_WIDTH = 26;
        public static readonly int NOTE_FULL_WIDTH =
            NOTE_WIDTH_PRE +
            NOTE_WIDTH;
        public static readonly int NOTE_LINE_LENGTH = 10;

        // Note bolletje en stokje hoogte 
        public static readonly int NOTE_LINE_HEIGHT = 42;
        public static readonly int NOTE_HEAD_HEIGHT = 12;



        // Piano lijn breedte (nodig voor toetsen)
        public static readonly int PIANO_LINE_WIDTH = 1;
        public static readonly int PIANO_HEIGHT = 300;
        public static readonly int PIANO_TEXT_HEIGHT = 40;

        // Witte piano toets
        public static readonly int WHITE_KEY_HEIGHT = PIANO_HEIGHT;
        public static readonly int WHITE_KEY_WIDTH = 80;
        public static readonly int WHITE_KEY_FULL_WIDTH =
            WHITE_KEY_WIDTH +
            PIANO_LINE_WIDTH;

        // Zwarte piano toets
        public static readonly int BLACK_KEY_HEIGHT =
            WHITE_KEY_HEIGHT / 2;
        public static readonly int BLACK_KEY_WIDTH = 45;
        public static readonly int BLACK_KEY_FULL_WIDTH =
            BLACK_KEY_WIDTH +
            PIANO_LINE_WIDTH;

        // Overige piano gegevens
        public static readonly int PIANO_WIDTH =
            PIANO_LINE_WIDTH +
            (Piano.OCTAVEN * 7 * WHITE_KEY_FULL_WIDTH);

        // Renderer functies
        public static void RenderPiano(Piano p, Size z, Graphics g)
        {
            // Bereken of pak wat standaard variabelen
            int top = (z.Height / 2) - (PIANO_HEIGHT / 2);
            int left = (z.Width / 2) - (PIANO_WIDTH / 2);
            int octaves = Piano.OCTAVEN;

            // Achtergrond legen
            g.FillRectangle(BRUSH_PROGRESS, left, top, PIANO_WIDTH, PIANO_HEIGHT);

            // Houdt bij waar we aan het tekenen zijn
            int x = left;
            int y = top;

            // Render alle octaves van de Piano
            for (int oct = 0; oct < octaves; oct++)
            {
                // Pak alle witte toetsen van dit octave
                List<PianoKey> whiteKeys = p.FindKeys(Piano.BASE_OCTAAF + oct, false);

                // Render alle witte toetsen van de Piano
                for (int k = 0; k < whiteKeys.Count; k++)
                {
                    PianoKey key = whiteKeys[k];
                    int rx = x + ((oct * 7) + k) * WHITE_KEY_FULL_WIDTH;

                    // Zet de Rectangle op
                    RECT.X = rx;
                    RECT.Y = y;
                    RECT.Width = WHITE_KEY_FULL_WIDTH;
                    RECT.Height = WHITE_KEY_HEIGHT;

                    // Teken de achtergrondkleur
                    g.FillRectangle(
                        key.Enabled ? BRUSH_PROGRESS : BRUSH_BACKGROUND,
                        RECT
                    );

                    // Teken de rand
                    g.DrawRectangle(
                        PEN,
                        RECT
                    );

                    // Zorg dat we relatief tot de onderkant werken en limiteer de hoogte
                    RECT.Y = RECT.Bottom;
                    RECT.Height = PIANO_TEXT_HEIGHT;
                    RECT.Y -= RECT.Height;

                    // Teken de tekst
                    g.DrawString(key.Name + key.Octave, FONT, BRUSH, RECT, STRING_FORMAT);
                }

                // Render alle witte toetsen van de Piano
                List<PianoKey> blackKeys = p.FindKeys(Piano.BASE_OCTAAF + oct, true);

                // Render alle zwarte toetsen van de Piano
                for (int k = 0; k < blackKeys.Count; k++)
                {
                    // Pak de toets
                    PianoKey key = blackKeys[k];
                    int rx = x + WHITE_KEY_FULL_WIDTH - (BLACK_KEY_FULL_WIDTH / 2) + (((oct * 7) + (k >= 2 ? k + 1 : k)) * WHITE_KEY_FULL_WIDTH);

                    // Zet de Rectangle op
                    RECT.X = rx;
                    RECT.Y = y;
                    RECT.Width = BLACK_KEY_FULL_WIDTH;
                    RECT.Height = BLACK_KEY_HEIGHT;

                    // Teken de achtergrondkleur
                    g.FillRectangle(key.Enabled ? BRUSH_PROGRESS : BRUSH, RECT);

                    // Teken de randjes
                    g.DrawRectangle(PEN, RECT);

                    // Zorg dat we relatief tot de onderkant werken en limiteer de hoogte
                    RECT.Y = RECT.Bottom;
                    RECT.Height = PIANO_TEXT_HEIGHT;
                    RECT.Y -= RECT.Height;

                    // Teken de tekst
                    g.DrawString(key.Name + key.Octave, FONT, BRUSH_BACKGROUND, RECT, STRING_FORMAT);
                }
            }
        }

        public static void RenderSong(SongPlayer sp, Size z, Graphics g)
        {
            Song s = sp.CurrentSong;

            if (s.Measures.Count < 1)
                return;

            int xPerMeasure = s.GetXPerMeasure();
            int measuresPerRow = CalculateMeasuresPerRow(xPerMeasure, z.Width);
            int measureCount = s.Measures.Count;
            int measureWidth = CalculateMeasureWidth(xPerMeasure);

            // Progress omrekenen van een fractie van Component X-coordinaten naar fracties van Measures
            double progressX = sp.Progress;
            double progressMeasure = progressX / (double)xPerMeasure;

            int progressMeasureID = (int)Math.Floor(progressMeasure);
            int progressDeltaX = (int)Math.Floor((progressMeasure % 1) * (double)measureWidth);

            int rowCount = CalculateRowCount(measureCount, measuresPerRow);

            int x = 0, y = 0, measureIndex = 0;
            for (int row = 0; row < rowCount; row++)
            {
                // Bereken de X en Y coordinaat van deze row
                x = 0;
                y = CalculateRowY(row);
                y += ROW_PADDING_VERTICAL;

                // Teken de G-Sleutel
                if (Launcher.DEBUG) g.FillRectangle(BRUSH_GREEN, x, y, G_KEY_PADDING_PRE, ROW_HEIGHT);
                x += G_KEY_PADDING_PRE;

                if (Launcher.DEBUG) g.FillRectangle(BRUSH_BLUE, x, y, G_KEY_WIDTH, ROW_HEIGHT);
                g.DrawImage(IMAGE_G_KEY, x, y, G_KEY_WIDTH, ROW_HEIGHT);
                x += G_KEY_WIDTH;

                if (Launcher.DEBUG) g.FillRectangle(BRUSH_GREEN, x, y, G_KEY_PADDING_POST, ROW_HEIGHT);
                x += G_KEY_PADDING_POST;

                // Teken de time signature
                //g.DrawString("")

                // Time signature verrekenen
                x += TIME_SIGNATURE_TOTAL_WIDTH;

                // Begin met het tekenen van de maten
                for (int i = 0; i < measuresPerRow; i++)
                {
                    // Pak het ID van deze Measure
                    int measureID = measureIndex + i;

                    // Als deze Measure niet bestaat dan zijn we klaar met renderen
                    if (measureID >= measureCount)
                        break;

                    // Pak de measure
                    Measure m = s.Measures.ElementAt(measureID);

                    // Teken de zwarte horizontale lijntjes als eerste zodat je ze altijd ziet
                    RenderRowLines(g, z, y);

                    // Als dit de measure is waarin we nu aan het afspelen zijn, teken een blauw lijntje!
                    if (measureID == progressMeasureID)
                    {
                        g.DrawLine(
                            PEN_PROGRESS,
                            x + progressDeltaX,
                            y - (4 * LINE_PADDING_VERTICAL),
                            x + progressDeltaX,
                            y + ROW_HEIGHT + (4 * LINE_PADDING_VERTICAL)
                        );
                    }

                    // Gooi een padding op de X aan het begin van de measure
                    if (Launcher.DEBUG) g.FillRectangle(BRUSH_GREEN, x, y, NOTE_PADDING, ROW_HEIGHT);
                    x += NOTE_PADDING;

                    // Itereer over alle X-posities
                    for (int j = 0; j < xPerMeasure; j++)
                    {
                        // Pak alle SongComponents op deze X-positie
                        List<SongComponent> comps = m.GetComponentsAt(j);

                        // Debug rendering
                        if (Launcher.DEBUG) g.FillRectangle(BRUSH_ORANGE, x, y, NOTE_WIDTH_PRE, ROW_HEIGHT);
                        if (Launcher.DEBUG) g.FillRectangle(BRUSH_RED, x + NOTE_WIDTH_PRE, y, NOTE_WIDTH, ROW_HEIGHT);
                        if (Launcher.DEBUG) g.FillRectangle(BRUSH_GREEN, x + NOTE_FULL_WIDTH, y, NOTE_PADDING, ROW_HEIGHT);

                        // Render de SongComponents
                        for (int k = 0; k < comps.Count; k++)
                        {
                            int dY = CalculateLineY(comps[k].Y, comps[k].Octave);

                            if (comps.Count == 1 && (j + 1) < m.Components.Count)
                            {
                                if (m.Components[j].Length == ComponentLength.EIGHTH && m.Components[j + 1].Length == ComponentLength.EIGHTH && m.Components[j].Octave == m.Components[j + 1].Octave && m.Components[j] is Note && m.Components[j + 1] is Note)
                                {
                                    if (m.Components[j].Octave == 4)
                                        g.DrawLine(PEN_TOPLINE, (x + NOTE_WIDTH + 5), (m.Components[j].Y * LINE_PADDING_VERTICAL + CalculateRowY(row) + 10), (x + NOTE_FULL_WIDTH + 5 + NOTE_PADDING + NOTE_WIDTH), (m.Components[j + 1].Y * LINE_PADDING_VERTICAL + CalculateRowY(row) + 10));
                                    else if (m.Components[j].Octave == 5)
                                    {
                                        g.DrawLine(PEN_TOPLINE, (x + NOTE_WIDTH_PRE + 3), (m.Components[j].Y * LINE_PADDING_VERTICAL + NOTE_LINE_HEIGHT + CalculateRowY(row) + 10), (x + NOTE_FULL_WIDTH  - 5 + NOTE_PADDING + NOTE_WIDTH), (m.Components[j + 1].Y * LINE_PADDING_VERTICAL + NOTE_LINE_HEIGHT + CalculateRowY(row) + 10));
                                    }
                                    RenderDoubleEighthSongComponent(g, m.Components[j], x, y - ROW_PADDING_VERTICAL);
                                    x += NOTE_FULL_WIDTH + NOTE_PADDING;
                                    RenderDoubleEighthSongComponent(g, m.Components[j + 1], x, y - ROW_PADDING_VERTICAL);

                                    j++;
                                }
                                else
                                    RenderSongComponent(g, comps[k], x, y - ROW_PADDING_VERTICAL);
                            }
                            else
                                // We hebben X en Y dus we gaan RENDEREN
                                RenderSongComponent(g, comps[k], x, y - ROW_PADDING_VERTICAL);

                            // Render de noot lengte als het relevant is
                            if (sp.NoteLengthEnabled)
                            {
                                int length = comps[k].GetLengthAsNumber() * (NOTE_PADDING + NOTE_FULL_WIDTH);
                                g.DrawLine(PEN_DEBUG, x + NOTE_WIDTH_PRE, y + (dY * LINE_PADDING_VERTICAL), (x + length) - NOTE_PADDING, y + (dY * LINE_PADDING_VERTICAL));
                            }
                        }

                        // Gooi een NOTE_FULL_WIDTH en een NOTE_PADDING er boven op
                        x += NOTE_FULL_WIDTH + NOTE_PADDING;

                    }

                    // Aan het eind van de measure moeten we de dikke streep meerekenen
                    x += MEASURE_BAR_WIDTH;

                    // Gooi measureWidth bovenop de X
                    //x += measureWidth;

                    // Nu kunnen we dus makkelijk het verticale lijntje tekenen aan het eind van de Measure.
                    g.FillRectangle(
                        BRUSH,
                        x - MEASURE_BAR_WIDTH,
                        y,
                        MEASURE_BAR_WIDTH,
                        ROW_HEIGHT
                    );
                }

                // Gooi measuresPerRow bovenop de measureIndex zodat hij volgende iteratie ook klopt
                measureIndex += measuresPerRow;
            }
        }

        public static void RenderSongComponent(Graphics g, SongComponent sc, int x, int y)
        {
            //int scY = CalculateLineY(sc.Y, sc.Octave);
            int scY = sc.Y + (1 + (Piano.BASE_OCTAAF - sc.Octave)) * 7;

            // Verreken de scY (lijn index) in de Y coordinaat
            y += (scY * LINE_PADDING_VERTICAL);
            y += (ROW_PADDING_COUNT - 3) * LINE_PADDING_VERTICAL;

            // Is het een noot?
            if (sc is Note)
            {
                Note n = (Note)sc;

                // Is hij zwart?
                if (n.Black)
                    g.DrawImage(IMAGE_NOTE_HASHTAG, x, y - 12);
            }

            // Gooi de HASHTAG/BES breedte op de X coordinaat
            x += NOTE_WIDTH_PRE;

            if (sc is Note)
            {
                // Horizontaal lijntje tekenen
                scY -= 3;
                if (scY % 2 == 0 && (scY < 0 || scY > 8)) //  Zit hij OVER het lijntje
                    g.DrawLine(PEN, x - NOTE_LINE_LENGTH, y, x + NOTE_RENDER_PADDING + NOTE_LINE_LENGTH, y);
                else if (scY < -1 && scY % 2 != 0) // Zit hij ONDER het lijntje
                    g.DrawLine(PEN, x - NOTE_LINE_LENGTH, y + LINE_PADDING_VERTICAL, x + NOTE_RENDER_PADDING + NOTE_LINE_LENGTH, y + LINE_PADDING_VERTICAL);
                else if (scY > 9 && scY % 2 != 0) // Zit hij BOVEN het lijntje
                    g.DrawLine(PEN, x - NOTE_LINE_LENGTH, y - LINE_PADDING_VERTICAL, x + NOTE_RENDER_PADDING + NOTE_LINE_LENGTH, y - LINE_PADDING_VERTICAL);
                scY += 3;

                if (sc.Octave != Piano.BASE_OCTAAF)
                {
                    // Kijkt welke noot afgebeeld moet worden op het notenschrift
                    switch (sc.Length)
                    {

                        case ComponentLength.FULL:
                            g.FillEllipse(BRUSH, x, y - 6, NOTE_RENDER_PADDING + 3, NOTE_HEAD_HEIGHT);
                            g.FillEllipse(BRUSH_BACKGROUND, x + 5, y - 5, 6, 9);
                            break;
                        case ComponentLength.HALF:
                            g.TranslateTransform(x, y);
                            g.RotateTransform(-30f);
                            g.TranslateTransform(-x, -y);

                            g.FillEllipse(BRUSH, x, y - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
                            g.FillEllipse(BRUSH_BACKGROUND, x + 2, y + 2, NOTE_RENDER_PADDING - 3, 4);
                            g.ResetTransform();

                            RenderStokje(g, false, x, y);
                            break;
                        case ComponentLength.QUARTER:
                            g.TranslateTransform(x, y);
                            g.RotateTransform(-30f);
                            g.TranslateTransform(-x, -y);

                            g.FillEllipse(BRUSH, x, y - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
                            g.ResetTransform();

                            RenderStokje(g, false, x, y);
                            break;
                        case ComponentLength.EIGHTH:
                            // Zorg dat we niet te ver naar links gaan
                            g.TranslateTransform(IMAGE_NOTE_EIGHT_FLAG.Width, 0);

                            // Draaien om het ovaaltje schuin te tekenen
                            g.TranslateTransform(x, y);
                            g.RotateTransform(-30f);
                            g.TranslateTransform(-x, -y);

                            // Ovaal schuin tekenen en resetten
                            g.FillEllipse(BRUSH, x, y - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
                            g.ResetTransform();

                            // Zorgen dat onze lijn en vlag ook wat opgeschoven zijn
                            g.TranslateTransform(IMAGE_NOTE_EIGHT_FLAG.Width, 0);
                            g.DrawImage(IMAGE_NOTE_EIGHT_FLAG_FLIP, x + 2, y - NOTE_LINE_HEIGHT + 52);
                            RenderStokje(g, false, x, y);

                            // Reset alsnog
                            g.ResetTransform();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    // Kijkt welke noot afgebeeld moet worden op het notenschrift
                    switch (sc.Length)
                    {
                        case ComponentLength.FULL:
                            g.FillEllipse(BRUSH, x, y - 6, NOTE_RENDER_PADDING + 3, 12);
                            g.FillEllipse(BRUSH_BACKGROUND, x + 5, y - 5, 6, 9);
                            break;
                        case ComponentLength.HALF:
                            g.TranslateTransform(x, y);
                            g.RotateTransform(-30f);
                            g.TranslateTransform(-x, -y);

                            g.FillEllipse(BRUSH, x, y - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
                            g.FillEllipse(BRUSH_BACKGROUND, x + 2, y + 2, NOTE_RENDER_PADDING - 3, 4);
                            g.ResetTransform();

                            RenderStokje(g, true, x, y);
                            break;
                        case ComponentLength.QUARTER:
                            g.TranslateTransform(x, y);
                            g.RotateTransform(-30f);
                            g.TranslateTransform(-x, -y);

                            g.FillEllipse(BRUSH, x, y - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
                            g.ResetTransform();

                            RenderStokje(g, true, x, y);
                            break;
                        case ComponentLength.EIGHTH:
                            g.TranslateTransform(x, y);
                            g.RotateTransform(-30f);
                            g.TranslateTransform(-x, -y);

                            g.FillEllipse(BRUSH, x, y - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
                            g.ResetTransform();

                            g.DrawImage(IMAGE_NOTE_EIGHT_FLAG, x + 14, y - NOTE_LINE_HEIGHT + 1);
                            RenderStokje(g, true, x, y);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                // Kijkt welke rust afgebeeld moet worden op het notenschrift
                switch (sc.Length)
                {
                    case ComponentLength.FULL: g.FillRectangle(BRUSH, x, y - 12, 15, 6); break;
                    case ComponentLength.HALF: g.FillRectangle(BRUSH, x, y - 6, 15, 6); break;
                    case ComponentLength.QUARTER: g.DrawImage(IMAGE_REST_QAURTER, x - 0, y - 17); break;
                    case ComponentLength.EIGHTH: g.DrawImage(IMAGE_REST_EIGHT, x - 0, y - 6); break;
                    default: break;
                }
            }
        }
        public static void RenderDoubleEighthSongComponent(Graphics g, SongComponent sc, int x, int y)
        {
            //int scY = CalculateLineY(sc.Y, sc.Octave);
            int scY = sc.Y + (1 + (Piano.BASE_OCTAAF - sc.Octave)) * 7;
            bool up = sc.Octave == 4 ? true : false;
            // Verreken de scY (lijn index) in de Y coordinaat
            y += (scY * LINE_PADDING_VERTICAL);
            y += (ROW_PADDING_COUNT - 3) * LINE_PADDING_VERTICAL;

            // Gooi de HASHTAG/BES breedte op de X coordinaat
            x += NOTE_WIDTH_PRE;

            // Horizontaal lijntje tekenen
            scY -= 3;
            if (scY % 2 == 0 && (scY < 0 || scY > 8)) //  Zit hij OVER het lijntje
                g.DrawLine(PEN, x - NOTE_LINE_LENGTH, y, x + NOTE_RENDER_PADDING + NOTE_LINE_LENGTH, y);
            else if (scY < -1 && scY % 2 != 0) // Zit hij ONDER het lijntje
                g.DrawLine(PEN, x - NOTE_LINE_LENGTH, y + LINE_PADDING_VERTICAL, x + NOTE_RENDER_PADDING + NOTE_LINE_LENGTH, y + LINE_PADDING_VERTICAL);
            else if (scY > 9 && scY % 2 != 0) // Zit hij BOVEN het lijntje
                g.DrawLine(PEN, x - NOTE_LINE_LENGTH, y - LINE_PADDING_VERTICAL, x + NOTE_RENDER_PADDING + NOTE_LINE_LENGTH, y - LINE_PADDING_VERTICAL);
            scY += 3;

            g.TranslateTransform(x, y);
            g.RotateTransform(-30f);
            g.TranslateTransform(-x, -y);

            g.FillEllipse(BRUSH, x, y - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
            g.ResetTransform();

            RenderStokje(g, up, x, y);
        }

        private static void RenderStokje(Graphics g, bool stokjeOmlaag, int x, int y)
        {
            if (stokjeOmlaag)
                g.FillRectangle(BRUSH, x + NOTE_RENDER_PADDING, y - NOTE_LINE_HEIGHT - 1, 2, NOTE_LINE_HEIGHT + 1);
            else
                g.FillRectangle(BRUSH, x + 2, y, 2, NOTE_LINE_HEIGHT);
        }


        public static void RenderRowLines(Graphics g, Size z, int rowY)
        {
            int y = rowY;
            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(PEN, 0, y, 0 + z.Width, y);
                //if (Launcher.DEBUG) g.FillRectangle(BRUSH_ORANGE, 0, y, 0 + z.Width, LINE_PADDING_VERTICAL);
                y += LINE_PADDING_VERTICAL;
                //if (Launcher.DEBUG) g.FillRectangle(BRUSH_PURPLE, 0, y, 0 + z.Width, LINE_PADDING_VERTICAL);
                y += LINE_PADDING_VERTICAL;
            }
        }

        // Berekenings functies
        public static int CalculateRowCount(int measureCount, int measuresPerRow)
        {
            return (int)Math.Ceiling(((double)measureCount) / (double)measuresPerRow);
        }

        public static int CalculateMeasuresPerRow(int xPerMeasure, int width)
        {
            int pre =
                G_KEY_TOTAL_WIDTH +
                TIME_SIGNATURE_TOTAL_WIDTH;

            double div = ((double)(width - pre)) / (double)CalculateMeasureWidth(xPerMeasure);
            return (int)Math.Floor(div);
        }

        public static int CalculateMeasureWidth(int xPerMeasure)
        {
            return NOTE_PADDING + ((NOTE_PADDING + NOTE_FULL_WIDTH) * xPerMeasure) + MEASURE_BAR_WIDTH;
        }

        public static int CalculateRowY(int row)
        {
            return OFFSET_Y + (ROW_TOTAL_HEIGHT * row);
        }

        public static int CalculateRowFromY(int y)
        {
            return (int)Math.Floor(((double)y) / (double)ROW_TOTAL_HEIGHT);
        }
        /*
        public static int GetMeasureFromCoords(int x, int y)
        {
            return -1;
        }

        public static int GetSongComponentFromCoords(int x, int y, ComponentLength length)
        {
            // Niet nodig om rekening met een G-sleutel of maat rekening te houden
            y = y % ROW_TOTAL_HEIGHT;
            
            // Calculate the Y coordinate (letter) for this SongComponent
            int scY = (int)Math.Floor(((double)y) / (double)LINE_PADDING_VERTICAL);
            if (scY < -3) scY = -3;
            if (scY > 11) scY = 11;

            // Calculate the X coordinate for this SongComponent
            
        }
        */
        public static int CalculateComponentX(int measuresPerRow, int xPerMeasure, int measure, int x)
        {
            int xPerRow = measuresPerRow * xPerMeasure;

            // Mocht de X groter zijn dan de aantal X-coordinaten in één Measure, dan pakken
            // we hiermee de X-coordinaat binnen de laatste Measure.
            x = x % (measuresPerRow * xPerMeasure);

            return G_KEY_TOTAL_WIDTH
                + TIME_SIGNATURE_TOTAL_WIDTH
                + (measure * CalculateMeasureWidth(xPerMeasure))
                + NOTE_PADDING
                + ((NOTE_PADDING + NOTE_FULL_WIDTH) * x);
        }

        public static int CalculateComponentY(int row, int y)
        {
            return CalculateRowY(row)
                + (LINE_PADDING_VERTICAL * y);
        }

        public static int CalculateLineY(int scY, int scOctave)
        {
            //return 0;
            return scY + 4 + ((Piano.BASE_OCTAAF - scOctave) * 7);

        }

        public static StringFormat GetCenteredStringFormat()
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            return sf;
        }
    }
}
