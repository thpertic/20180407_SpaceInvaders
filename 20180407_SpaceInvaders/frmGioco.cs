using System;
using System.IO;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _20180407_SpaceInvaders
{
    public partial class frmSpaceInvaders : Form
    {
        // conto intermittenza
        private byte nFlash;

        private byte i;
        private byte j;

        private byte alienoPrecedente = 0;
        private byte alienoCorrente;

        const int sleep = 5000;
        const byte nAlieni = 21;
        private const byte lungOb = 18, altOb = 8;

        List<PictureBox> listaFuoco = new List<PictureBox>();
        List<PictureBox> listaFuocoNemico = new List<PictureBox>();
        List<Control> aliens = new List<Control>(nAlieni);

        Random rand = new Random();

        List<List<PictureBox>> obstacle = new List<List<PictureBox>>(lungOb);
        List<List<PictureBox>> obstacle1 = new List<List<PictureBox>>(lungOb);

        private bool _moveLeft;
        private bool _moveRight;

        private bool creati = false;
        private bool nuovoLivello = false;
        private bool invincibile = false;

        private int x, y;
        private int life;

        private string maxName;
        private int maxScore = 0;

        private int direzioneAlieni = 1;
        private byte rateFuoco = 20;

        // lunghezze "logiche" degli ostacoli
        private byte[] lung0 = new byte[lungOb], lung1 = new byte[lungOb];
        private byte[] lungA0 = new byte[lungOb], lungA1 = new byte[lungOb];

        private byte level = 1;

        Stopwatch stopwatch = new Stopwatch();
        Stopwatch swColpito = new Stopwatch();

        /**************************************** INIZIO PROGRAMMA ****************************************/
        public frmSpaceInvaders()
        {
            InitializeComponent();
            timeMove.Tick += timeMove_Tick;
        }

        private void frmSpaceInvaders_Load(object sender, EventArgs e)
        {
            Form frmStart = new frmStart();
            if (frmStart.ShowDialog() != DialogResult.OK)
                Close();

            
            if (File.Exists(Program.filename))
            {
                File.Decrypt(Program.filename);
                StreamReader FileR = new StreamReader(Program.filename);

                string[] file = FileR.ReadLine().Split(' ');
                maxName = file[0];
                maxScore = Convert.ToInt32(file[1]);

                FileR.Close();
                File.Encrypt(Program.filename);
            }
            CreaOggettiAsync();

            timeMove.Start();
            stopwatch.Start();
        }

        /// <summary>
        /// Metodo che aggiorna lo stato del gioco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeMove_Tick(object sender, EventArgs e)
        {
            // if (creati)
            //     mostraLivello(sleep);

            lblPunteggio.Text = Program.score.ToString();
            lblMassimoPunteggio.Text = maxName + " " + maxScore.ToString();

            // muove la nave
            moveShip();

            stampaVita(true);

            Control[] giocatore = this.Controls.Find("pictSpaceship", true);
            Control[] alieni = this.Controls.Find("alien", true);
            Control[] ostacoli = this.Controls.Find("obstacle", true);



            if (alieni.Length > 0 )//|| creati)
            {
                bool boolAlieno = false;
                // ciclo principale per il movimento e le intersezioni del fuoco del player
                for (i = (byte)listaFuoco.Count; i > 0; i--)
                {

                    bool boolOstacolo = false;

                    // testa se uno degli alieni viene colpito
                    for (j = (byte)alieni.Length; j > 0 && !boolAlieno; j--)
                        if (Colpito(listaFuoco[i - 1], alieni[j - 1]))
                        {
                            // se il fuoco lo colpisce aumenta il fuoco
                            Program.score++;
                            if (Program.score > maxScore)
                            {
                                maxName = "---";
                                maxScore = Program.score;
                            }                             


                            if (alieni.Length == 0)
                                nuovoLivello = true;

                            // elimina tutti gli oggetti che collidono
                            eliminaOggetto(alieni[j - 1]);
                            eliminaOggetto(listaFuoco[i - 1]);

                            aliens.Remove(alieni[j - 1]);
                            listaFuoco.Remove(listaFuoco[i - 1]);

                            boolAlieno = true;
                        }
                    // ciclo su tutti gli ostacoli
                    for (int j = ostacoli.Length; j > 0 && !boolOstacolo && !boolAlieno; j--)
                        if (Colpito(listaFuoco[i - 1], ostacoli[j - 1]))
                        {
                            // testa quale ostacolo
                            if (ostacoli[j - 1].Location.X < this.Width)
                            {
                                // cerca per ogni "pixel" di ostacolo
                                for (byte k = altOb; k > 0; k--)
                                    for (byte x = lung0[k]; x > 0; x--)
                                        if (obstacle[k - 1][x - 1].Bounds == ostacoli[j - 1].Bounds)
                                        {
                                            obstacle[k - 1].Remove((PictureBox)ostacoli[j - 1]);
                                            lung0[x - 1]--;

                                            break;
                                        }
                            }
                            else
                            {
                                for (byte k = altOb; k > 0; k--)
                                    for (byte x = lung1[k]; x > 0; x--)
                                        if (obstacle1[k - 1][x - 1].Bounds == ostacoli[j - 1].Bounds)
                                        {
                                            obstacle1[k].Remove((PictureBox)ostacoli[j - 1]);
                                            lung1[x - 1]--;

                                            break;
                                        }
                            }
                            // elimina tutti gli oggetti che collidono
                            eliminaOggetto(ostacoli[j - 1]);
                            eliminaOggetto(listaFuoco[i - 1]);

                            listaFuoco.Remove(listaFuoco[i - 1]);
                            boolOstacolo = true;
                        }
                    if(listaFuoco.Count > 0 && !(boolAlieno || boolOstacolo))
                    {
                        listaFuoco[i - 1].Top -= 15;

                        if (listaFuoco[i - 1] != null && listaFuoco[i - 1].Location.Y < 0)
                            eliminaOggetto(listaFuoco[i - 1]);
                    }

                    // per trillo <3 :-*
                    // break;
                }

                //ciclo per il fuoco avversario
                for (i = (byte)listaFuocoNemico.Count; i > 0 ; i--)
                {
                    bool boolPlayer = false;
                    bool boolOstacolo = false;

                    // cerca la collisioni con la navicella
                    if (Colpito(listaFuocoNemico[i - 1], giocatore[0]) && !invincibile)
                    { 
                        if (!invincibile)
                            life--;
                        invincibile = true;

                        if (life == 0)
                        {
                            perso();

                            Thread.CurrentThread.Abort();
                            Close();
                            Dispose();

                            // break;
                        }
                        stampaVita(false);

                        // invincibilità - respawn a intermittenza nave
                        intermittenza();

                        // elimina tutti gli oggetti che collidono
                        eliminaOggetto(listaFuocoNemico[i - 1]);
                        listaFuocoNemico.Remove(listaFuocoNemico[i - 1]);

                        boolPlayer = true;

                    }
                    for (int j = ostacoli.Length; j > 0 && !boolOstacolo && !boolPlayer; j--)
                        if (Colpito(listaFuocoNemico[i - 1], ostacoli[j - 1]))
                        {
                            // elimina tutti gli oggetti che collidono
                            eliminaOggetto(ostacoli[j - 1]);
                            eliminaOggetto(listaFuocoNemico[i - 1]);

                            if (ostacoli[j - 1].Location.X < this.Width)
                            {
                                for (byte k = altOb; k > 0; k--)
                                    for (byte x = lungA0[k]; x > 0; x--)
                                        if (obstacle[k - 1][x - 1].Bounds == ostacoli[j - 1].Bounds)
                                        {
                                            obstacle[k - 1].Remove((PictureBox)ostacoli[j - 1]);
                                            lungA0[x - 1]--;

                                            break;
                                        }
                            }
                            else
                            {
                                for (byte k = altOb; k > 0; k--)
                                    for (byte x = lungA1[k]; x > 0; x--)
                                        if (obstacle1[k][x].Bounds == ostacoli[j - 1].Bounds)
                                        {
                                            obstacle1[k].Remove((PictureBox)ostacoli[j - 1]);
                                            lungA1[x - 1]--;

                                            break;
                                        }
                            }
                            listaFuocoNemico.Remove(listaFuocoNemico[i - 1]);

                            boolOstacolo = true;
                        }
                    if (listaFuocoNemico.Count > 0 && !(boolOstacolo || boolPlayer))
                    {
                        listaFuocoNemico[i - 1].Top += 15;

                        if (listaFuocoNemico[i - 1] != null && listaFuocoNemico[i - 1].Location.Y > this.Size.Height)
                            eliminaOggetto(listaFuocoNemico[i - 1]);
                    }
                }

                if (stopwatch.ElapsedTicks % rateFuoco == 0)
                {
                    // sceglie un avversario random e lo fa sparare
                    Control control;
                    do
                    {
                        alienoCorrente = (byte)rand.Next(0, alieni.Length - 1);
                        control = alieni[alienoCorrente];
                    } while (alienoPrecedente == alienoCorrente);
                    alienoPrecedente = alienoCorrente;

                    var fuocoNemico = new PictureBox
                    {
                        Name = "fuocoNemico",
                        Size = new Size(5, 14),
                        Location = new Point(control.Location.X + 15, control.Location.Y),
                        BackColor = Color.DarkGreen,
                        Visible = true,
                        Enabled = true
                    };

                    this.Controls.Add(fuocoNemico);
                    listaFuocoNemico.Add(fuocoNemico);
                }
                
                // PROBLEMA: QUANDO SI SVUOTA L'ARRAY DEGLI ALIENI ENTRA SEMPRE IN BORDO = TRUE
                // DIREZIONEALIENI VA SEMPRE A 1
                // OGNI VOLTA DI SPOSTAMENTO() VIENE CAMBIATO ANCHE 

                /***************************************************************************************************************
                 * CICLO CONTROLLA 1/3 ALIENI A SECONDA DELLA DIREZIONE
                 */
                
                // controllo dell'alieno piu esterno a seconda della direzioneAlieni
                Control alienoBordo = alieni[0];
                int m = alieni[0].Location.X;

                // trova l'alieno al bordo
                for(i = 1; i < alieni.Length; i++)
                {
                    if (direzioneAlieni < 0)
                    {
                        if (alieni[i].Location.X < m)
                        {
                            m = alieni[i].Location.X;
                            alienoBordo = alieni[i];
                        }
                    }
                    else if (direzioneAlieni > 0)
                    {
                        if (alieni[i].Location.X > m)
                        {
                            m = alieni[i].Location.X;
                            alienoBordo = alieni[i];
                        }
                    }
                }             

                // ciclo per il movimento degli alieni
                for (i = 0; i < alieni.Length; i++)
                    alieni[i].Left += direzioneAlieni;

                // test se l'alieno al bordo ha colpito il bordo
                bool bordo = false;
                if (direzioneAlieni < 0)
                {
                    if (alienoBordo.Location.X <= 50)
                        bordo = true;
                }
                else if(direzioneAlieni > 0)
                {
                    if (alienoBordo.Location.X + 41 >= this.Width - 50)
                        bordo = true;
                }
                
                if (bordo)
                {
                    for (i = 0; i < alieni.Length; i++)
                        spostamento(alieni[i]);
                    direzioneAlieni = -direzioneAlieni;
                }

                creati = false;
            }
            if(nuovoLivello)
            {
                level++;
                rateFuoco -= 5;

                DistruggiOggetti();
                CreaOggettiAsync();

                mostraLivello(sleep);

                
                // TUTTI GLI OGGETTI .DISPOSE()
                // POSSIBILE ANCHE FARLO ASINCRONO

                // POI CREAOGGETTIASYNC()
                
                //MessageBox.Show("Hai vinto!");
                // System.Threading.Thread.Sleep(sleep);
                // CreaOggettiAsync(sender, e);
            }

        }
        
        private void intermittenza()
        {
            timeColpito.Start();
        }

        private void timeColpito_Tick(object sender, EventArgs e)
        {
            pictSpaceship.Visible = !pictSpaceship.Visible;
             nFlash++;
            
            if(nFlash == 10)
            {
                pictSpaceship.Visible = true;
                invincibile = false;
                nFlash = 0;

                timeColpito.Stop();
            }
        }

        private void perso()
        {
            // TODO: Mettere in pausa il thread
            // bool flag = false;

            // while (!flag)
            // {
            timeMove.Stop();

            // int perso = await Task<int>.Run(() =>
            // {
                MessageBox.Show("Hai perso!");
                Form frmHighScore = new frmHighScore();
                frmHighScore.ShowDialog();

                // scrittura su file
                if (File.Exists(Program.filename))
                {
                    StreamWriter FileW = new StreamWriter(Program.filename);
                    FileW.Write(Program.score);
                    FileW.Close();
                }
                else
                {
                    FileStream FileC = new FileStream(Program.filename, FileMode.Create);
                    FileC.Close();

                    StreamWriter FileW = new StreamWriter(Program.filename);
                    FileW.Write(Program.score);
                    FileW.Close();
                }

                // flag = true;
                // return 1;
            // });
            timeMove.Start();
            // System.Threading.Thread.Sleep(1);
            // }
        }

        private void spostamento(Control alieno)
        {
            if (alieno.Location.Y + alieno.Size.Height < obstacle[0][0].Location.Y)
                alieno.Top += 20;
            else
                Close();
        }
        private void eliminaOggetto(Control oggetto)
        {
            this.Controls.Remove(oggetto);
            oggetto.Dispose();
        }
        private void stampaVita(bool condizione)
        {
            Control[] vite = this.Controls.Find("life", true);

            if (condizione)
            {
                // per stampare la vita rimasta
                int cont = 0;
                for (i = 0; i < vite.Length; i++)
                {
                    if (cont < life)
                    {
                        vite[i].Visible = true;
                        cont++;
                    }
                }
            }
            else 
                // "azzera" la vita graficamente
                for (i = 0; i < vite.Length; i++)
                    vite[i].Visible = false;
        }

        /// <summary>
        /// Metodo per testare se si è colpito il nemico o un ostacolo
        /// </summary>
        /// <param name="oggetto"></param>
        /// <param name="toHitObject"></param>
        /// <returns></returns>
        private bool Colpito(Control oggetto, Control toHitObject)
        {
            // se interseca -> true
            if (oggetto.Bounds.IntersectsWith(toHitObject.Bounds))
                return true;
 
            return false;
        }

        /********************************************
         * Vari metodi per il movimento della nave
         */
        private void moveShip()
        {
            if (_moveLeft)
                pictSpaceship.Left += -15;

            if (_moveRight)
                pictSpaceship.Left += 15;
        }
        private void frmSpaceInvaders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if (pictSpaceship.Location.X - 20 < 0)
                    _moveLeft = false;
                else
                    _moveLeft = true;
                _moveRight = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                _moveLeft = false;
                if ((pictSpaceship.Location.X + pictSpaceship.Width + 25) > this.Size.Width)
                    _moveRight = false;
                else
                    _moveRight = true;
            }
        }
        private void frmSpaceInvaders_KeyUp(object sender, KeyEventArgs e)
        {
            _moveLeft = false;
            _moveRight = false;
        }

        /// <summary>
        /// Dopo il click di qualcosa sulla scena si genera un fuoco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictAlien36_Click(object sender, EventArgs e)
        {
            var fire = new PictureBox
            {
                Name = "fire",
                Size = new Size(5, 14),
                Location = new Point(pictSpaceship.Location.X + 15, pictSpaceship.Location.Y),
                BackColor = Color.Blue,
                Visible = true
            };

            this.Controls.Add(fire); 
            listaFuoco.Add( fire);
        }

        /// <summary>
        /// fissa la label con il numero del livello a schermo
        /// </summary>
        /// <param name="tempo"></param>
        private async void mostraLivello(int tempo)
        {
            var l = new Label
            {
                AutoSize = true,
                Name = "Level",
                Text = "Level 0" + level,
                Location = new Point(250, 338),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                Visible = true
            };
            l.BringToFront();

            Controls.Add(l);
            await Task.Delay(tempo);

            Thread.Sleep(tempo * 12);
            Controls.Remove(l);
        }

        /************************************************************************************
         *
         * Distrugge oggetti rimasti (in teoria solo ostacoli)
         *
         */
        private void DistruggiOggetti()
        {
            // Control[] alieni = this.Controls.Find("alien", true);
            Control[] ostacoli = this.Controls.Find("obstacle", true);

            for(int i = 0; i < ostacoli.Length; i++)
                this.Controls.Remove(ostacoli[i]);
        }

        /************************************************************************************
         * 
         * 
         * Creazione oggetti di gioco
         * 
         * 
         */
        private async void CreaOggettiAsync()
        {
            creati = true;
            life = 3;

            Form frmCaricamento = new frmCaricamento();
            frmCaricamento.Show();


            List<Control> oggetti = await Task<int>.Run(() =>
            {
                List<Control> controlli = new List<Control>();

                byte i, j;

                int cont = 0;
                int grPixel = 5;

                // creazione alieni
                x = 100;
                y = 110;
                for (i = (byte) 0; aliens.Count < nAlieni; i++)
                {
                    if (i % 7 == 0)
                    {
                        y += 50;
                        cont = 0;
                    }

                    var alien = new PictureBox
                    {
                        Name = "alien",
                        BackColor = Color.Transparent,
                        Image = global::_20180407_SpaceInvaders.Properties.Resources.alien,
                        Location = new Point(x + cont * 100, y),
                        Size = new Size(41, 28),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    alien.Click += new EventHandler(PictAlien36_Click);

                    cont++;

                    aliens.Add(alien);
                    controlli.Add(alien);

                    Program.progress++;
                }

                // creazione ostacoli
                x = 150;
                y = 450;

                for (i = 0; i < altOb; i++)
                {
                    obstacle.Add(new List<PictureBox>(lungOb));
                    // obstacle[i] = new List<PictureBox>(lungOb);
                    for (j = 0; j < lungOb; j++)
                    {
                        // I TORNA A 0??



                        // crea un particolare di ostacolo, con tutte le proprietà
                        var ostacolo = new PictureBox
                        {
                            Name = "obstacle",
                            BackColor = Color.Red,
                            Location = new Point(x + j * grPixel, y),
                            Size = new Size(grPixel, grPixel),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        ostacolo.Click += new EventHandler(PictAlien36_Click);

                        obstacle[i].Add(ostacolo);
                        controlli.Add(ostacolo);

                        Program.progress++;
                    }
                    y += 5;
                }

                // creazione ostacoli
                x = 575;
                y = 450;

                for (i = 0; i < altOb; i++)
                {
                    obstacle1.Add(new List<PictureBox>(lungOb));
                    for (j = 0; j < lungOb; j++)
                    {
                        var ostacolo1 = new PictureBox
                        {
                            Name = "obstacle",
                            BackColor = Color.Red,
                            Location = new Point(x + j * grPixel, y),
                            Size = new Size(grPixel, grPixel),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        ostacolo1.Click += new EventHandler(PictAlien36_Click);

                        obstacle1[i].Add(ostacolo1);
                        controlli.Add(ostacolo1);

                        Program.progress++;
                    }
                    y += 5;
                }
                
                //creazione vite 
                x = 650;
                y = 9;

                for(i = 0; i < life; i++)
                {
                    var vita = new PictureBox
                    {
                        Name = "life",
                        BackColor = Color.Yellow,
                        Location = new Point(x + i * 50, y),
                        Size = new Size(32, 32),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Visible = false
                    };
                    vita.Click += new EventHandler(PictAlien36_Click);

                    controlli.Add(vita);
                    Program.progress++;
                }

                return controlli;
            });

            for (int i = 0; i < oggetti.Count; i++)
                this.Controls.Add(oggetti[i]);

            mostraLivello(100);
        }
    }
}