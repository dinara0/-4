namespace лаба_4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Coord_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Clear_button = new System.Windows.Forms.Button();
            this.ShowCircle_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Coord_label
            // 
            this.Coord_label.AutoSize = true;
            this.Coord_label.Location = new System.Drawing.Point(12, 311);
            this.Coord_label.Name = "Coord_label";
            this.Coord_label.Size = new System.Drawing.Size(94, 20);
            this.Coord_label.TabIndex = 1;
            this.Coord_label.Text = "Coord_label";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 293);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            // 
            // Clear_button
            // 
            this.Clear_button.Location = new System.Drawing.Point(81, 334);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(125, 40);
            this.Clear_button.TabIndex = 2;
            this.Clear_button.Text = "очистить панель";
            this.Clear_button.UseVisualStyleBackColor = true;
            this.Clear_button.Click += new System.EventHandler(this.Clear_button_Click);
            // 
            // ShowCircle_button
            // 
            this.ShowCircle_button.Location = new System.Drawing.Point(212, 334);
            this.ShowCircle_button.Name = "ShowCircle_button";
            this.ShowCircle_button.Size = new System.Drawing.Size(158, 40);
            this.ShowCircle_button.TabIndex = 3;
            this.ShowCircle_button.Text = "показать объекты хранилища";
            this.ShowCircle_button.UseVisualStyleBackColor = true;
            this.ShowCircle_button.Click += new System.EventHandler(this.ShowCircle_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowCircle_button);
            this.Controls.Add(this.Clear_button);
            this.Controls.Add(this.Coord_label);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Coord_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Clear_button;
        private System.Windows.Forms.Button ShowCircle_button;
    }
}

