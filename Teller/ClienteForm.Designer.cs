namespace Teller
{
    partial class ClienteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buscarClienteBtn = new System.Windows.Forms.Button();
            this.cedulaTextBox = new System.Windows.Forms.TextBox();
            this.labelCedulaCliente = new System.Windows.Forms.Label();
            this.errorClienteLabel = new System.Windows.Forms.Label();
            this.loadingPic = new System.Windows.Forms.PictureBox();
            this.pictureBoxFotoCliente = new System.Windows.Forms.PictureBox();
            this.nombreClienteFijoLabel = new System.Windows.Forms.Label();
            this.nombreclienteLabel = new System.Windows.Forms.Label();
            this.fechaNacimientoLabel = new System.Windows.Forms.Label();
            this.fechaNacimientoFijaLabel = new System.Windows.Forms.Label();
            this.nacionalidadLabel = new System.Windows.Forms.Label();
            this.nacionalidadFijaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFotoCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // buscarClienteBtn
            // 
            this.buscarClienteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarClienteBtn.Location = new System.Drawing.Point(296, 109);
            this.buscarClienteBtn.Name = "buscarClienteBtn";
            this.buscarClienteBtn.Size = new System.Drawing.Size(197, 44);
            this.buscarClienteBtn.TabIndex = 0;
            this.buscarClienteBtn.Text = "Buscar Cliente";
            this.buscarClienteBtn.UseVisualStyleBackColor = true;
            this.buscarClienteBtn.Click += new System.EventHandler(this.buscarClienteBtn_Click);
            // 
            // cedulaTextBox
            // 
            this.cedulaTextBox.Location = new System.Drawing.Point(297, 61);
            this.cedulaTextBox.Name = "cedulaTextBox";
            this.cedulaTextBox.Size = new System.Drawing.Size(196, 20);
            this.cedulaTextBox.TabIndex = 1;
            // 
            // labelCedulaCliente
            // 
            this.labelCedulaCliente.AutoSize = true;
            this.labelCedulaCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCedulaCliente.Location = new System.Drawing.Point(197, 61);
            this.labelCedulaCliente.Name = "labelCedulaCliente";
            this.labelCedulaCliente.Size = new System.Drawing.Size(59, 20);
            this.labelCedulaCliente.TabIndex = 2;
            this.labelCedulaCliente.Text = "Cedula";
            // 
            // errorClienteLabel
            // 
            this.errorClienteLabel.AutoSize = true;
            this.errorClienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorClienteLabel.Location = new System.Drawing.Point(349, 169);
            this.errorClienteLabel.Name = "errorClienteLabel";
            this.errorClienteLabel.Size = new System.Drawing.Size(70, 25);
            this.errorClienteLabel.TabIndex = 3;
            this.errorClienteLabel.Text = "label1";
            this.errorClienteLabel.Visible = false;
            // 
            // loadingPic
            // 
            this.loadingPic.Image = global::Teller.Properties.Resources.loadinggif;
            this.loadingPic.Location = new System.Drawing.Point(508, 109);
            this.loadingPic.Name = "loadingPic";
            this.loadingPic.Size = new System.Drawing.Size(51, 44);
            this.loadingPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingPic.TabIndex = 4;
            this.loadingPic.TabStop = false;
            this.loadingPic.Visible = false;
            // 
            // pictureBoxFotoCliente
            // 
            this.pictureBoxFotoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFotoCliente.Location = new System.Drawing.Point(296, 207);
            this.pictureBoxFotoCliente.Name = "pictureBoxFotoCliente";
            this.pictureBoxFotoCliente.Size = new System.Drawing.Size(196, 228);
            this.pictureBoxFotoCliente.TabIndex = 5;
            this.pictureBoxFotoCliente.TabStop = false;
            this.pictureBoxFotoCliente.Visible = false;
            // 
            // nombreClienteFijoLabel
            // 
            this.nombreClienteFijoLabel.AutoSize = true;
            this.nombreClienteFijoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreClienteFijoLabel.Location = new System.Drawing.Point(191, 453);
            this.nombreClienteFijoLabel.Name = "nombreClienteFijoLabel";
            this.nombreClienteFijoLabel.Size = new System.Drawing.Size(93, 25);
            this.nombreClienteFijoLabel.TabIndex = 6;
            this.nombreClienteFijoLabel.Text = "Nombre";
            this.nombreClienteFijoLabel.Visible = false;
            // 
            // nombreclienteLabel
            // 
            this.nombreclienteLabel.AutoSize = true;
            this.nombreclienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreclienteLabel.Location = new System.Drawing.Point(437, 453);
            this.nombreclienteLabel.Name = "nombreclienteLabel";
            this.nombreclienteLabel.Size = new System.Drawing.Size(87, 25);
            this.nombreclienteLabel.TabIndex = 7;
            this.nombreclienteLabel.Text = "Nombre";
            this.nombreclienteLabel.Visible = false;
            // 
            // fechaNacimientoLabel
            // 
            this.fechaNacimientoLabel.AutoSize = true;
            this.fechaNacimientoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaNacimientoLabel.Location = new System.Drawing.Point(437, 497);
            this.fechaNacimientoLabel.Name = "fechaNacimientoLabel";
            this.fechaNacimientoLabel.Size = new System.Drawing.Size(87, 25);
            this.fechaNacimientoLabel.TabIndex = 9;
            this.fechaNacimientoLabel.Text = "Nombre";
            this.fechaNacimientoLabel.Visible = false;
            // 
            // fechaNacimientoFijaLabel
            // 
            this.fechaNacimientoFijaLabel.AutoSize = true;
            this.fechaNacimientoFijaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaNacimientoFijaLabel.Location = new System.Drawing.Point(191, 498);
            this.fechaNacimientoFijaLabel.Name = "fechaNacimientoFijaLabel";
            this.fechaNacimientoFijaLabel.Size = new System.Drawing.Size(234, 25);
            this.fechaNacimientoFijaLabel.TabIndex = 8;
            this.fechaNacimientoFijaLabel.Text = "Fecha de Nacimiento";
            this.fechaNacimientoFijaLabel.Visible = false;
            // 
            // nacionalidadLabel
            // 
            this.nacionalidadLabel.AutoSize = true;
            this.nacionalidadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nacionalidadLabel.Location = new System.Drawing.Point(437, 540);
            this.nacionalidadLabel.Name = "nacionalidadLabel";
            this.nacionalidadLabel.Size = new System.Drawing.Size(87, 25);
            this.nacionalidadLabel.TabIndex = 11;
            this.nacionalidadLabel.Text = "Nombre";
            this.nacionalidadLabel.Visible = false;
            // 
            // nacionalidadFijaLabel
            // 
            this.nacionalidadFijaLabel.AutoSize = true;
            this.nacionalidadFijaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nacionalidadFijaLabel.Location = new System.Drawing.Point(191, 540);
            this.nacionalidadFijaLabel.Name = "nacionalidadFijaLabel";
            this.nacionalidadFijaLabel.Size = new System.Drawing.Size(149, 25);
            this.nacionalidadFijaLabel.TabIndex = 10;
            this.nacionalidadFijaLabel.Text = "Nacionalidad";
            this.nacionalidadFijaLabel.Visible = false;
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 639);
            this.Controls.Add(this.nacionalidadLabel);
            this.Controls.Add(this.nacionalidadFijaLabel);
            this.Controls.Add(this.fechaNacimientoLabel);
            this.Controls.Add(this.fechaNacimientoFijaLabel);
            this.Controls.Add(this.nombreclienteLabel);
            this.Controls.Add(this.nombreClienteFijoLabel);
            this.Controls.Add(this.pictureBoxFotoCliente);
            this.Controls.Add(this.loadingPic);
            this.Controls.Add(this.errorClienteLabel);
            this.Controls.Add(this.labelCedulaCliente);
            this.Controls.Add(this.cedulaTextBox);
            this.Controls.Add(this.buscarClienteBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClienteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ClienteForm";
            ((System.ComponentModel.ISupportInitialize)(this.loadingPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFotoCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buscarClienteBtn;
        private System.Windows.Forms.TextBox cedulaTextBox;
        private System.Windows.Forms.Label labelCedulaCliente;
        private System.Windows.Forms.Label errorClienteLabel;
        public System.Windows.Forms.PictureBox loadingPic;
        private System.Windows.Forms.PictureBox pictureBoxFotoCliente;
        private System.Windows.Forms.Label nombreClienteFijoLabel;
        private System.Windows.Forms.Label nombreclienteLabel;
        private System.Windows.Forms.Label fechaNacimientoLabel;
        private System.Windows.Forms.Label fechaNacimientoFijaLabel;
        private System.Windows.Forms.Label nacionalidadLabel;
        private System.Windows.Forms.Label nacionalidadFijaLabel;
    }
}