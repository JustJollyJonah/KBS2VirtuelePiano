using KBS2VirtuelePiano.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2VirtuelePiano.Helper
{
    public static class EditorHelper
    {
        // Brushes, pennen en font
        public static readonly Brush BRUSH = new SolidBrush(Color.Black);
        public static readonly Brush BRUSH_BACKGROUND = new SolidBrush(Color.White);
        public static readonly Pen PEN = new Pen(BRUSH, 1.0f);
        public static readonly Pen THICKER_PEN = new Pen(BRUSH, 2.0f);

        // Hoogte van één Y coördinaat
        public static readonly int LINE_PADDING_VERTICAL = 6;
        public static readonly int LINE_COUNT = 5;
        public static readonly int NOTE_RENDER_PADDING = 13;
        public static readonly int NOTE_HEAD_HEIGHT = 12;

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

        // Padding en breedte van een noot (incl. vlaggetjes)
        public static readonly int NOTE_WIDTH_PRE = 16;
        public static readonly int NOTE_WIDTH = 26;
        public static readonly int NOTE_FULL_WIDTH = NOTE_WIDTH_PRE + NOTE_WIDTH;
        public static readonly int NOTE_LINE_HEIGHT = 42;
        public static readonly int NOTE_LINE_LENGTH = 10;

        //Noten plus vlaggetjes
        public static readonly Image IMAGE_NOTE_EIGHT_FLAG = Properties.Resources.AchsteNoot_vlaggetje;
        public static readonly Image IMAGE_NOTE_EIGHT_FLAG_FLIP = Properties.Resources.AchsteNoot_vlaggetje_flip;
        public static readonly Image IMAGE_NOTE_BES = Properties.Resources.Note_HASHTAG;

        //Rusten
        public static readonly Image IMAGE_REST_FULL = Properties.Resources.REST_FULL_HALF;
        public static readonly Image IMAGE_REST_HALF = Properties.Resources.REST_FULL_HALF;
        public static readonly Image IMAGE_REST_QAURTER = Properties.Resources.RestQuarter;
        public static readonly Image IMAGE_REST_EIGHT = Properties.Resources.RestEighth;

        //Functie rendert horizontale muzieklijnen
        public static void RenderRowLines(Graphics g, Size z, int rowY)
        {
            int y = rowY;
            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(PEN, 0, y, 0 + z.Width, y);
                y += LINE_PADDING_VERTICAL;
                y += LINE_PADDING_VERTICAL;
            }
            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(PEN, i * (NOTE_FULL_WIDTH * 8), LINE_PADDING_VERTICAL * 3, i * (NOTE_FULL_WIDTH * 8), LINE_PADDING_VERTICAL * 11);
            }
        }

        //Render normale songcomponts
        public static void RenderSongComponent(Graphics g, List<SongComponent> listSc)
        {
            foreach (var sa in listSc)
            {
                //Verkrijg x en y van songcomponent
                int x = sa.X;
                int y = sa.Octave == 4 ? sa.Y + 7 : sa.Y;
                bool stokjeOmhoog = sa.Octave == 4 ? true : false;

                //Set grid coordinaten om naar realtime coordinaten
                int realX = x * NOTE_FULL_WIDTH;
                int realY = y * LINE_PADDING_VERTICAL;

                //Als de songcomponent een noot is
                if (sa is Note)
                {
                    Note sc = (Note)sa;
                    //Als onderstaande voorwaarde true is wordt er een kruis voor de noot getekend
                    if (sc.Black)
                        g.DrawImage(IMAGE_NOTE_BES, realX - 11, realY - 12);
                    //Zoekt de juiste lengte bij een noot en tekend die
                    switch (sc.Length)

                    {
                        case ComponentLength.FULL:
                            g.FillEllipse(BRUSH, realX, realY - 6, NOTE_RENDER_PADDING + 3, NOTE_HEAD_HEIGHT);
                            g.FillEllipse(BRUSH_BACKGROUND, realX + 5, realY - 5, 6, 9);
                            RenderVerticalLine(g, y, realX, realY);
                            break;
                        case ComponentLength.HALF:
                            g.TranslateTransform(realX, realY);
                            g.RotateTransform(-30f);
                            g.TranslateTransform(-realX, -realY);

                            g.FillEllipse(BRUSH, realX, realY - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
                            g.FillEllipse(BRUSH_BACKGROUND, realX + 2, realY + 2, NOTE_RENDER_PADDING - 3, 4);
                            g.ResetTransform();
                            RenderStokje(g, stokjeOmhoog, realX, realY, NOTE_LINE_HEIGHT);
                            RenderVerticalLine(g, y, realX, realY);
                            break;
                        case ComponentLength.QUARTER:
                            g.TranslateTransform(realX, realY);
                            g.RotateTransform(-30f);
                            g.TranslateTransform(-realX, -realY);
                            g.FillEllipse(BRUSH, realX, realY - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
                            g.ResetTransform();
                            RenderVerticalLine(g, y, realX, realY);
                            RenderStokje(g, stokjeOmhoog, realX, realY, NOTE_LINE_HEIGHT);
                            break;
                        case ComponentLength.EIGHTH:
                            //Als het stokje van een noot omhoog moet
                            if (stokjeOmhoog)
                            {
                                g.TranslateTransform(realX, realY);
                                g.RotateTransform(-30f);
                                g.TranslateTransform(-realX, -realY);

                                g.FillEllipse(BRUSH, realX, realY - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
                                g.ResetTransform();

                                g.DrawImage(IMAGE_NOTE_EIGHT_FLAG, realX + 14, realY - NOTE_LINE_HEIGHT + 1);
                                RenderVerticalLine(g, y, realX, realY);
                                RenderStokje(g, true, realX, realY, NOTE_LINE_HEIGHT);
                            }
                            else
                            {
                                // Zorg dat we niet te ver naar links gaan
                                g.TranslateTransform(IMAGE_NOTE_EIGHT_FLAG.Width, 0);

                                // Draaien om het ovaaltje schuin te tekenen
                                g.TranslateTransform(realX, realY);
                                g.RotateTransform(-30f);
                                g.TranslateTransform(-realX, -realY);

                                // Ovaal schuin tekenen en resetten
                                g.FillEllipse(BRUSH, realX, realY - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
                                g.ResetTransform();

                                // Zorgen dat onze lijn en vlag ook wat opgeschoven zijn
                                g.TranslateTransform(IMAGE_NOTE_EIGHT_FLAG.Width, 0);
                                g.DrawImage(IMAGE_NOTE_EIGHT_FLAG_FLIP, realX +3, realY - NOTE_LINE_HEIGHT + 52);
                                RenderStokje(g, false, realX, realY, NOTE_LINE_HEIGHT);
                                RenderVerticalLine(g, y, realX, realY);
                                // Reset alsnog
                                g.ResetTransform();
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (sa is Rest)
                {
                    //Als de songcomponent een rust tekent die deze
                    RenderRest(g, realX, sa.Y * LINE_PADDING_VERTICAL, sa);
                }
            }
        }
        public static void RenderEightsSpecial(Graphics g, List<SongComponent> listSc)
        {
            for(int i = 0; i < listSc.Count; i++)
            {
                SongComponent sa = listSc[i];
                //Verkrijg x en y van songcomponent
                int x = sa.X;
                int y = sa.Octave == 4 ? sa.Y + 7 : sa.Y;
                bool up = sa.Octave == 4 ? true : false;
                int indexLast = listSc.Count - 1;
                int xLast = (listSc[indexLast].X * NOTE_FULL_WIDTH) + NOTE_RENDER_PADDING;
                int yLast = (listSc[indexLast].Y * LINE_PADDING_VERTICAL);
                int xFirst = (listSc[0].X * NOTE_FULL_WIDTH) + NOTE_RENDER_PADDING;
                int yFirst = (listSc[0].Y * LINE_PADDING_VERTICAL);
                
                //Set grid coordinaten om naar realtime coordinaten
                int realX = x * NOTE_FULL_WIDTH;
                int realY = y * LINE_PADDING_VERTICAL;

                //Als onderstaande voorwaarde true is wordt er een kruis voor de noot getekend
                Note sc = (Note)sa;
                if (sc.Black)
                    g.DrawImage(IMAGE_NOTE_BES, (realX - 11), realY - 12);

                g.TranslateTransform(realX, realY);
                g.RotateTransform(-30f);
                g.TranslateTransform(-realX, -realY);
                g.FillEllipse(BRUSH, realX, realY - 2, NOTE_RENDER_PADDING + 1, NOTE_HEAD_HEIGHT);
                g.ResetTransform();

                RenderVerticalLine(g, y, realX, realY);
                if (i == 0)
                {
                    RenderStokje(g, up, realX, realY, NOTE_LINE_HEIGHT);
                    if (up)
                        g.DrawLine(THICKER_PEN, xFirst, yFirst, xLast, yLast);
                    else
                        g.DrawLine(THICKER_PEN, xFirst - 11, yFirst + NOTE_LINE_HEIGHT, xLast - 9, yLast + NOTE_LINE_HEIGHT);
                }
                else if (i == (listSc.Count - 1))
                    RenderStokje(g, up, realX, realY, NOTE_LINE_HEIGHT);               
            }
        }
        private static void RenderStokje(Graphics g, bool stokjeOmlaag, int x, int y, int length)
        {
            if (stokjeOmlaag)
                g.FillRectangle(BRUSH, x + NOTE_RENDER_PADDING, y - length - 1, 2, length + 1);
            else
                g.FillRectangle(BRUSH, x + 2, y, 2, length);
        }

        //Het lijntje wat door een noot gaat, bijv bij de lage c
        private static void RenderVerticalLine(Graphics g, int y, int realX, int realY)
        {
            y -= 3;
            if (y % 2 == 0 && (y < 0 || y > 8)) //  Zit hij OVER het lijntje
                g.DrawLine(PEN, realX - NOTE_LINE_LENGTH, realY, realX + NOTE_RENDER_PADDING + NOTE_LINE_LENGTH, realY);
            else if (y < -1 && y % 2 != 0) // Zit hij ONDER het lijntje
                g.DrawLine(PEN, realX - NOTE_LINE_LENGTH, realY + LINE_PADDING_VERTICAL, realX + NOTE_RENDER_PADDING + NOTE_LINE_LENGTH, realY + LINE_PADDING_VERTICAL);
            else if (y > 9 && y % 2 != 0) // Zit hij BOVEN het lijntje
                g.DrawLine(PEN, realX - NOTE_LINE_LENGTH, realY - LINE_PADDING_VERTICAL, realX + NOTE_RENDER_PADDING + NOTE_LINE_LENGTH, realY - LINE_PADDING_VERTICAL);
            y += 3;
        }

        private static void RenderRest(Graphics g, int realX, int realY, SongComponent sc)
        {
            switch (sc.Length)
            {
                case ComponentLength.FULL: g.FillRectangle(BRUSH, realX, realY + 30, 15, 6); break;
                case ComponentLength.HALF: g.FillRectangle(BRUSH, realX, realY + 37, 15, 6); break;
                case ComponentLength.QUARTER: g.DrawImage(IMAGE_REST_QAURTER, realX - 0, realY + 28); break;
                case ComponentLength.EIGHTH: g.DrawImage(IMAGE_REST_EIGHT, realX - 0, realY + 30); break;
                default: break;
            }
        }

        public static bool ValidateDoubleInput(List<SongComponent> list, int mouseX, int mouseY)
        {
            foreach (var item in list)
            {
                if (item.X == mouseX && item.Y == mouseY)
                    return false;
            }
            return true;
        }
    }
}
