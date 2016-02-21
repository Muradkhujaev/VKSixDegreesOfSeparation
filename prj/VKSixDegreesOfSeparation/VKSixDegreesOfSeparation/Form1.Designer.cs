namespace VKSixDegreesOfSeparation
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.findConnectionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // findConnectionButton
            // 
            this.findConnectionButton.Location = new System.Drawing.Point(12, 12);
            this.findConnectionButton.Name = "findConnectionButton";
            this.findConnectionButton.Size = new System.Drawing.Size(203, 89);
            this.findConnectionButton.TabIndex = 0;
            this.findConnectionButton.Text = "Find Connection";
            this.findConnectionButton.UseVisualStyleBackColor = true;
            this.findConnectionButton.Click += new System.EventHandler(this.findConnectionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 485);
            this.Controls.Add(this.findConnectionButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button findConnectionButton;
    }
}

