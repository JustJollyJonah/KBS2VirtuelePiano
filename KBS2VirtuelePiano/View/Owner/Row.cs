using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KBS2VirtuelePiano.Helper;
using KBS2VirtuelePiano.Model;

namespace KBS2VirtuelePiano.View
{
    public partial class Row : Control
    {
        //X en Y positie voor het positioneren van een row
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        //Houdt laatste cursor coordinaten bij
        public int MouseX { get; set; }
        public int MouseY { get; set; }
        //Houdt laatste cursor coordinaten bij, speciaal voor menu, omdat bij het selecteren in het menu de vorige mouseX en mouseY veranderen
        private int LastMouseXForContextMenu;
        private int LastMouseYForContextMenu;
        public ContextMenu contextProperties = new ContextMenu();

        public bool hover;

        //Het aantal vakken in het grid
        public readonly int NUMBER_OF_X = 24;
        public readonly int NUMBER_OF_Y = 14;

        //Hier worden de songcomponents in bijgehouden
        public List<SongComponent> ListWithSongComponents { get; set; }
        // tweedimensionalelist, voor noot koppeling
        public List<List<SongComponent>> ListWithRefactoredSongComponents { get; set; }

        public Row(int y, int index)
        {
            this.PositionX = 0;
            this.PositionY = y;
            this.Width = NUMBER_OF_X * EditorHelper.NOTE_FULL_WIDTH;
            this.Height = NUMBER_OF_Y * EditorHelper.LINE_PADDING_VERTICAL;
            this.BackColor = System.Drawing.Color.White;
            this.Location = new System.Drawing.Point(this.PositionX, this.PositionY);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(MouseMoveFunction);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(AddSongComponentToSong);
            this.MouseEnter += new System.EventHandler(MouseEnterFunction);
            this.MouseLeave += new System.EventHandler(MouseLeaveFunction);
            this.ListWithSongComponents = new List<SongComponent>();
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            //Maakt de getekende objecten strakker getekend
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            //Teken muzieklijnen
            EditorHelper.RenderRowLines(g, this.ClientSize, 3 * EditorHelper.LINE_PADDING_VERTICAL);
            //Maakt van de enkele list een dubbele lijst, zodat deze meegegeven kan worden aan de rendersongcomponent
            ListWithRefactoredSongComponents = RefactorListToMultiList(ListWithSongComponents);

            //Kijkt of er noten zijn die aan elkaar getekend moeten worden, zo ja dan stuurt die deze door naar een speciale renderer
            foreach (var list in ListWithRefactoredSongComponents)
                if (list.Count == 1)
                    EditorHelper.RenderSongComponent(g, list);
                else
                    EditorHelper.RenderEightsSpecial(g, list);
            List<SongComponent> tempList = new List<SongComponent>();
            tempList.Add(new Note() { Length = ComponentLength.QUARTER, Black = false, X = MouseX, Y = MouseY });
            if (hover)
                EditorHelper.RenderSongComponent(g, tempList);
        }

        //Houd cursor coordinaten bij
        private void MouseMoveFunction(object sender, MouseEventArgs e)
        {
            this.MouseX = e.X / EditorHelper.NOTE_FULL_WIDTH;
            this.MouseY = e.Y / (EditorHelper.LINE_PADDING_VERTICAL);
        }

        private void MouseLeaveFunction(object sender, EventArgs e)
        {
            hover = false;
        }

        private void MouseEnterFunction(object sender, EventArgs e)
        {
            hover = true;
        }

        private void AddSongComponentToSong(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Als er nog geen noot op de posisitie is zal er een nieuwe bijgetekend worden
                if (EditorHelper.ValidateDoubleInput(ListWithSongComponents, MouseX, MouseY))
                {
                    ListWithSongComponents.Add(new Note(Note.GetNoteLetterFromY(MouseY), Note.GetOctaveFromY(MouseY), false, ComponentLength.QUARTER, MouseX));
                    ListWithSongComponents = ListWithSongComponents.OrderBy(x => x.X).ToList();
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                //Open een submenu waar noten verandert kunnen worden
                LastMouseXForContextMenu = e.X / EditorHelper.NOTE_FULL_WIDTH;
                LastMouseYForContextMenu = e.Y / EditorHelper.LINE_PADDING_VERTICAL;
                CreateMyMenu();
            }
        }

        public List<List<SongComponent>> RefactorListToMultiList(List<SongComponent> list)
        {
            List<List<SongComponent>> doubleList = new List<List<SongComponent>>();
            for (int i = 0; i < list.Count; i++)
            {
                //Als het lijstje groot genoeg is om naar de volgende index te kijken
                if (list.Count > (i + 1))
                {
                    //Kijkt of de volgende obecten wel achtste noten zijn
                    if (list[i].Length == ComponentLength.EIGHTH && list[(i + 1)].Length == ComponentLength.EIGHTH && list[i] is Note && list[i + 1] is Note && list[i].Octave == list[i + 1].Octave)
                    {
                        List<SongComponent> tempList = new List<SongComponent>();
                        tempList.Add(list[i]);
                        tempList.Add(list[i + 1]);
                        doubleList.Add(tempList);
                        i += 1;
                    }
                    else
                    {
                        List<SongComponent> tempList = new List<SongComponent>();
                        tempList.Add(list[i]);
                        doubleList.Add(tempList);
                    }
                }
                else
                {
                    List<SongComponent> tempList = new List<SongComponent>();
                    tempList.Add(list[i]);
                    doubleList.Add(tempList);
                }
            }
            return doubleList;
        }

        //Deze functie creert submenu voor als er op de rechtermuisknop geklikt is, spreekt voor zich
        public void CreateMyMenu()
        {
            // Create a main menu object.
            ContextMenu mainMenu1 = new ContextMenu();

            // Create empty menu item objects.
            MenuItem topMenuItem = new MenuItem();
            MenuItem topMenuItem2 = new MenuItem();
            MenuItem topMenuItem4 = new MenuItem();
            MenuItem topMenuItem5 = new MenuItem();
            MenuItem menuItem11 = new MenuItem();
            MenuItem menuItem12 = new MenuItem();
            MenuItem menuItem13 = new MenuItem();
            MenuItem menuItem14 = new MenuItem();
            MenuItem menuItem21 = new MenuItem();
            MenuItem menuItem22 = new MenuItem();
            MenuItem menuItem23 = new MenuItem();
            MenuItem menuItem24 = new MenuItem();

            // Set the caption of the menu items.
            topMenuItem.Text = "&Lengte";
            menuItem11.Text = "&Hele noot";
            menuItem12.Text = "&Halve noot";
            menuItem13.Text = "&Kwart noot";
            menuItem14.Text = "&Achtste noot";
            topMenuItem2.Text = "&Rusten";
            menuItem21.Text = "&Hele rust";
            menuItem22.Text = "&Halve rust";
            menuItem23.Text = "&Kwart rust";
            menuItem24.Text = "&Achtste rust";
            topMenuItem4.Text = "&Kruis";
            topMenuItem5.Text = "Verwijderen";

            // Add the menu items to the main menu.
            topMenuItem.MenuItems.Add(menuItem11);
            topMenuItem.MenuItems.Add(menuItem12);
            topMenuItem.MenuItems.Add(menuItem13);
            topMenuItem.MenuItems.Add(menuItem14);
            topMenuItem2.MenuItems.Add(menuItem21);
            topMenuItem2.MenuItems.Add(menuItem22);
            topMenuItem2.MenuItems.Add(menuItem23);
            topMenuItem2.MenuItems.Add(menuItem24);
            mainMenu1.MenuItems.Add(topMenuItem);
            mainMenu1.MenuItems.Add(topMenuItem2);
            mainMenu1.MenuItems.Add(topMenuItem4);
            mainMenu1.MenuItems.Add(topMenuItem5);

            // Add functionality to the menu items using the Click event. 
            menuItem11.Click += new System.EventHandler(this.WholeNote_Click);
            menuItem12.Click += new System.EventHandler(this.HalfNote_Click);
            menuItem13.Click += new System.EventHandler(this.QuarterNote_Click);
            menuItem14.Click += new System.EventHandler(this.EighthNote_Click);
            menuItem21.Click += new System.EventHandler(this.WholeRest_Click);
            menuItem22.Click += new System.EventHandler(this.HalfRest_Click);
            menuItem23.Click += new System.EventHandler(this.QuarterRest_Click);
            menuItem24.Click += new System.EventHandler(this.EighthRest_Click);
            topMenuItem4.Click += new System.EventHandler(this.Flat_Click);
            topMenuItem5.Click += new System.EventHandler(this.Delete_Click);

            // Assign mainMenu1 to the form.
            this.ContextMenu = mainMenu1;

            if (ListWithSongComponents.Select(x => x).Where(x => x.X == LastMouseXForContextMenu && x.Y == LastMouseYForContextMenu).FirstOrDefault() is Rest)
                topMenuItem2.Enabled = false;
        }
        //Verandert gerichte object naar een hele noot
        private void WholeNote_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ListWithSongComponents.Count; i++)
            {
                int yWaarde = ListWithSongComponents[i].Octave == 4 ? ListWithSongComponents[i].Y + 7 : ListWithSongComponents[i].Y;
                if (ListWithSongComponents[i].X == LastMouseXForContextMenu && yWaarde == LastMouseYForContextMenu)
                {
                    ListWithSongComponents[i].Length = ComponentLength.FULL;
                }
            }
        }
        //Verandert gerichte object naar een halve noot
        private void HalfNote_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ListWithSongComponents.Count; i++)
            {
                int yWaarde = ListWithSongComponents[i].Octave == 4 ? ListWithSongComponents[i].Y + 7 : ListWithSongComponents[i].Y;
                if (ListWithSongComponents[i].X == LastMouseXForContextMenu && yWaarde == LastMouseYForContextMenu)
                    ListWithSongComponents[i].Length = ComponentLength.HALF;
            }
        }
        //Verandert gerichte object naar een kwart noot
        private void QuarterNote_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ListWithSongComponents.Count; i++)
            {
                int yWaarde = ListWithSongComponents[i].Octave == 4 ? ListWithSongComponents[i].Y + 7 : ListWithSongComponents[i].Y;
                if (ListWithSongComponents[i].X == LastMouseXForContextMenu && yWaarde == LastMouseYForContextMenu)
                    ListWithSongComponents[i].Length = ComponentLength.QUARTER;
            }
        }
        //Verandert gerichte object naar achtste noot
        private void EighthNote_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ListWithSongComponents.Count; i++)
            {
                int yWaarde = ListWithSongComponents[i].Octave == 4 ? ListWithSongComponents[i].Y + 7 : ListWithSongComponents[i].Y;
                if (ListWithSongComponents[i].X == LastMouseXForContextMenu && yWaarde == LastMouseYForContextMenu)
                    ListWithSongComponents[i].Length = ComponentLength.EIGHTH;
            }

        }
        //Verandert gerichte object naar een hele rust
        private void WholeRest_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ListWithSongComponents.Count; i++)
            {
                int yWaarde = ListWithSongComponents[i].Octave == 4 ? ListWithSongComponents[i].Y + 7 : ListWithSongComponents[i].Y;
                if (ListWithSongComponents[i].X == LastMouseXForContextMenu && yWaarde == LastMouseYForContextMenu)
                {
                    ListWithSongComponents[i] = new Rest(ComponentLength.FULL, LastMouseXForContextMenu);
                }
            }
        }
        //Verandert gerichte object naar een halve rust
        private void HalfRest_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ListWithSongComponents.Count; i++)
            {
                int yWaarde = ListWithSongComponents[i].Octave == 4 ? ListWithSongComponents[i].Y + 7 : ListWithSongComponents[i].Y;
                if (ListWithSongComponents[i].X == LastMouseXForContextMenu && yWaarde == LastMouseYForContextMenu)
                {
                    ListWithSongComponents[i] = new Rest(ComponentLength.HALF, LastMouseXForContextMenu);
                }
            }
        }
        //Verandert gerichte object naar een kwartrust
        private void QuarterRest_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ListWithSongComponents.Count; i++)
            {
                int yWaarde = ListWithSongComponents[i].Octave == 4 ? ListWithSongComponents[i].Y + 7 : ListWithSongComponents[i].Y;
                if (ListWithSongComponents[i].X == LastMouseXForContextMenu && yWaarde == LastMouseYForContextMenu)
                {
                    ListWithSongComponents[i] = new Rest(ComponentLength.QUARTER, LastMouseXForContextMenu);
                }
            }
        }

        //Verandert gerichte object naar een achtste rust
        private void EighthRest_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ListWithSongComponents.Count; i++)
            {
                int yWaarde = ListWithSongComponents[i].Octave == 4 ? ListWithSongComponents[i].Y + 7 : ListWithSongComponents[i].Y;
                if (ListWithSongComponents[i].X == LastMouseXForContextMenu && yWaarde == LastMouseYForContextMenu)
                {
                    ListWithSongComponents[i] = new Rest(ComponentLength.EIGHTH, LastMouseXForContextMenu);
                }
            }
        }

        //Tekent een kruis voor een noot
        private void Flat_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ListWithSongComponents.Count; i++)
            {
                int yWaarde = ListWithSongComponents[i].Octave == 4 ? ListWithSongComponents[i].Y + 7 : ListWithSongComponents[i].Y;
                if (ListWithSongComponents[i].X == LastMouseXForContextMenu && yWaarde == LastMouseYForContextMenu)
                {
                    Note tempNote = (Note)ListWithSongComponents[i];
                    if (!tempNote.Black)
                        tempNote.Black = true;
                    else
                        tempNote.Black = false;
                    ListWithSongComponents[i] = tempNote;
                }
            }
        }

        //Verwijdert object waar op gericht is
        private void Delete_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < ListWithSongComponents.Count; i++)
            {
                int yWaarde = ListWithSongComponents[i].Octave == 4 ? ListWithSongComponents[i].Y + 7 : ListWithSongComponents[i].Y;
                if (ListWithSongComponents[i].X == LastMouseXForContextMenu && yWaarde == LastMouseYForContextMenu)
                {
                    ListWithSongComponents.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
