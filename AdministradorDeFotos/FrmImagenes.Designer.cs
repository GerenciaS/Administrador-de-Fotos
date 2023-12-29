using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AdministradorDeFotos
{
    partial class FrmImagenes
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private IContainer components = null;

        private GroupBox groupBox1;
        private TextBox txtRuta;
        private Label label1;
        private DataGridView GridImagenes;
        private PictureBox PBImagen;
        private Button cmdExaminar;
        private Button cmdGuardarBD;
        private Button cmdGuardarLocal;
        private Button cmdActualizar;
        private FolderBrowserDialog folderBrowserDialog1;
        private DataGridViewTextBoxColumn RutaCompleta;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Mod;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripStatusLabel toolStripStatusLabel2;



        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImagenes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdActualizar = new System.Windows.Forms.Button();
            this.cmdExaminar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GridImagenes = new System.Windows.Forms.DataGridView();
            this.RutaCompleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PBImagen = new System.Windows.Forms.PictureBox();
            this.cmdGuardarBD = new System.Windows.Forms.Button();
            this.cmdGuardarLocal = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridImagenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagen)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdActualizar);
            this.groupBox1.Controls.Add(this.cmdExaminar);
            this.groupBox1.Controls.Add(this.txtRuta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.GridImagenes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 479);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmdActualizar
            // 
            this.cmdActualizar.Image = ((System.Drawing.Image)(resources.GetObject("cmdActualizar.Image")));
            this.cmdActualizar.Location = new System.Drawing.Point(643, 12);
            this.cmdActualizar.Name = "cmdActualizar";
            this.cmdActualizar.Size = new System.Drawing.Size(30, 27);
            this.cmdActualizar.TabIndex = 4;
            this.cmdActualizar.UseVisualStyleBackColor = true;
            this.cmdActualizar.Click += new System.EventHandler(this.cmdActualizar_Click);
            // 
            // cmdExaminar
            // 
            this.cmdExaminar.Location = new System.Drawing.Point(607, 11);
            this.cmdExaminar.Name = "cmdExaminar";
            this.cmdExaminar.Size = new System.Drawing.Size(30, 27);
            this.cmdExaminar.TabIndex = 3;
            this.cmdExaminar.Text = "...";
            this.cmdExaminar.UseVisualStyleBackColor = true;
            this.cmdExaminar.Click += new System.EventHandler(this.cmdExaminar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.Location = new System.Drawing.Point(148, 11);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(453, 29);
            this.txtRuta.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta de trabajo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // GridImagenes
            // 
            this.GridImagenes.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.GridImagenes.AllowUserToAddRows = false;
            this.GridImagenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GridImagenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridImagenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RutaCompleta,
            this.Nombre,
            this.Mod});
            this.GridImagenes.Location = new System.Drawing.Point(6, 60);
            this.GridImagenes.Name = "GridImagenes";
            this.GridImagenes.ReadOnly = true;
            this.GridImagenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridImagenes.Size = new System.Drawing.Size(668, 413);
            this.GridImagenes.TabIndex = 0;
            this.GridImagenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridImagenes_CellClick);
            this.GridImagenes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridImagenes_RowEnter);
            this.GridImagenes.Enter += new System.EventHandler(this.GridImagenes_Enter);
            // 
            // RutaCompleta
            // 
            this.RutaCompleta.HeaderText = "Ruta Completa";
            this.RutaCompleta.Name = "RutaCompleta";
            this.RutaCompleta.ReadOnly = true;
            this.RutaCompleta.Width = 102;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 69;
            // 
            // Mod
            // 
            this.Mod.HeaderText = "modificado";
            this.Mod.Name = "Mod";
            this.Mod.ReadOnly = true;
            this.Mod.Visible = false;
            this.Mod.Width = 83;
            // 
            // PBImagen
            // 
            this.PBImagen.Location = new System.Drawing.Point(698, 19);
            this.PBImagen.Name = "PBImagen";
            this.PBImagen.Size = new System.Drawing.Size(346, 290);
            this.PBImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBImagen.TabIndex = 1;
            this.PBImagen.TabStop = false;
            // 
            // cmdGuardarBD
            // 
            this.cmdGuardarBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGuardarBD.Location = new System.Drawing.Point(698, 317);
            this.cmdGuardarBD.Name = "cmdGuardarBD";
            this.cmdGuardarBD.Size = new System.Drawing.Size(346, 92);
            this.cmdGuardarBD.TabIndex = 2;
            this.cmdGuardarBD.Text = "Guardar en Base de datos";
            this.cmdGuardarBD.UseVisualStyleBackColor = true;
            this.cmdGuardarBD.Click += new System.EventHandler(this.cmdGuardarBD_Click);
            // 
            // cmdGuardarLocal
            // 
            this.cmdGuardarLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGuardarLocal.Location = new System.Drawing.Point(698, 415);
            this.cmdGuardarLocal.Name = "cmdGuardarLocal";
            this.cmdGuardarLocal.Size = new System.Drawing.Size(346, 63);
            this.cmdGuardarLocal.TabIndex = 3;
            this.cmdGuardarLocal.Text = "Guardar en Ruta de Trabajo";
            this.cmdGuardarLocal.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1056, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(939, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // FrmImagenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 539);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmdGuardarLocal);
            this.Controls.Add(this.cmdGuardarBD);
            this.Controls.Add(this.PBImagen);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmImagenes";
            this.Text = "Administrar imagenes";
            this.Load += new System.EventHandler(this.FrmImagenes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridImagenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagen)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

