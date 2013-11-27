namespace UDP
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnKill = new System.Windows.Forms.Button();
            this.btnRestartServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClientIP = new System.Windows.Forms.TextBox();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.dtgClientes = new System.Windows.Forms.DataGridView();
            this.routedItemListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Metrica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routedItemListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(12, 12);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(75, 23);
            this.btnKill.TabIndex = 0;
            this.btnKill.Text = "Kill server";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // btnRestartServer
            // 
            this.btnRestartServer.Location = new System.Drawing.Point(93, 12);
            this.btnRestartServer.Name = "btnRestartServer";
            this.btnRestartServer.Size = new System.Drawing.Size(75, 23);
            this.btnRestartServer.TabIndex = 1;
            this.btnRestartServer.Text = "Restart server";
            this.btnRestartServer.UseVisualStyleBackColor = true;
            this.btnRestartServer.Click += new System.EventHandler(this.btnRestartServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Clients:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Adicionar client:";
            // 
            // txtClientIP
            // 
            this.txtClientIP.Location = new System.Drawing.Point(100, 70);
            this.txtClientIP.Name = "txtClientIP";
            this.txtClientIP.Size = new System.Drawing.Size(156, 20);
            this.txtClientIP.TabIndex = 5;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(262, 68);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(75, 23);
            this.btnAddClient.TabIndex = 6;
            this.btnAddClient.Text = "Add Client";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(72, 48);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(58, 13);
            this.lblServerIP.TabIndex = 7;
            this.lblServerIP.Text = "lblServerIP";
            // 
            // dtgClientes
            // 
            this.dtgClientes.AllowUserToAddRows = false;
            this.dtgClientes.AllowUserToDeleteRows = false;
            this.dtgClientes.AutoGenerateColumns = false;
            this.dtgClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Destino,
            this.Metrica,
            this.Saida});
            this.dtgClientes.DataSource = this.routedItemListBindingSource;
            this.dtgClientes.Location = new System.Drawing.Point(13, 118);
            this.dtgClientes.Name = "dtgClientes";
            this.dtgClientes.ReadOnly = true;
            this.dtgClientes.RowHeadersVisible = false;
            this.dtgClientes.Size = new System.Drawing.Size(511, 268);
            this.dtgClientes.TabIndex = 8;
            // 
            // routedItemListBindingSource
            // 
            this.routedItemListBindingSource.DataSource = typeof(UDP.Model.RoutedItemList);
            // 
            // Destino
            // 
            this.Destino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Destino.DataPropertyName = "IpToSend";
            this.Destino.FillWeight = 50.74626F;
            this.Destino.HeaderText = "Destino";
            this.Destino.Name = "Destino";
            this.Destino.ReadOnly = true;
            this.Destino.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Metrica
            // 
            this.Metrica.DataPropertyName = "Metric";
            this.Metrica.FillWeight = 149.2537F;
            this.Metrica.HeaderText = "Métrica";
            this.Metrica.Name = "Metrica";
            this.Metrica.ReadOnly = true;
            this.Metrica.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Metrica.Width = 50;
            // 
            // Saida
            // 
            this.Saida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Saida.DataPropertyName = "Output";
            this.Saida.HeaderText = "Saída";
            this.Saida.Name = "Saida";
            this.Saida.ReadOnly = true;
            this.Saida.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 398);
            this.Controls.Add(this.dtgClientes);
            this.Controls.Add(this.lblServerIP);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.txtClientIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRestartServer);
            this.Controls.Add(this.btnKill);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dtgClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routedItemListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Button btnRestartServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClientIP;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.DataGridView dtgClientes;
        private System.Windows.Forms.BindingSource routedItemListBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Metrica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saida;
    }
}

