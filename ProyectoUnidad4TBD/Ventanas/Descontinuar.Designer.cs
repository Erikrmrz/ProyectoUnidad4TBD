
namespace ProyectoUnidad4TBD
{
    partial class Descontinuar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Descontinuar));
            dtvProductos = new DataGridView();
            label1 = new Label();
            txtCodigoBarras = new TextBox();
            btnDescontinuar = new Button();
            ((System.ComponentModel.ISupportInitialize)dtvProductos).BeginInit();
            SuspendLayout();
            // 
            // dtvProductos
            // 
            dtvProductos.BackgroundColor = Color.DarkGray;
            dtvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtvProductos.GridColor = Color.White;
            dtvProductos.Location = new Point(12, 96);
            dtvProductos.Name = "dtvProductos";
            dtvProductos.RowHeadersWidth = 51;
            dtvProductos.Size = new Size(847, 309);
            dtvProductos.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.Gray;
            label1.Font = new Font("Dubai", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(69, 52);
            label1.Name = "label1";
            label1.Size = new Size(136, 25);
            label1.TabIndex = 1;
            label1.Text = "Codigo de barras";
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.BackColor = Color.LightGray;
            txtCodigoBarras.Location = new Point(239, 52);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(217, 27);
            txtCodigoBarras.TabIndex = 2;
            txtCodigoBarras.KeyUp += txtCodigoBarras_KeyUp;
            // 
            // btnDescontinuar
            // 
            btnDescontinuar.BackColor = Color.DarkGray;
            btnDescontinuar.ForeColor = Color.Black;
            btnDescontinuar.Location = new Point(331, 430);
            btnDescontinuar.Name = "btnDescontinuar";
            btnDescontinuar.Size = new Size(232, 38);
            btnDescontinuar.TabIndex = 3;
            btnDescontinuar.Text = "Descontinuar";
            btnDescontinuar.UseVisualStyleBackColor = false;
            btnDescontinuar.Click += btnDescontinuar_Click;
            // 
            // Descontinuar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(922, 528);
            Controls.Add(btnDescontinuar);
            Controls.Add(txtCodigoBarras);
            Controls.Add(label1);
            Controls.Add(dtvProductos);
            Name = "Descontinuar";
            Text = "Descontinuar";
            ((System.ComponentModel.ISupportInitialize)dtvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private DataGridView dtvProductos;
        private Label label1;
        private TextBox txtCodigoBarras;
        private Button btnDescontinuar;
    }
}