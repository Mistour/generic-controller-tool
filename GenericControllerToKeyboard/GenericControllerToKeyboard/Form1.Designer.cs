namespace GenericControllerToKeyboard
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.controllerListBox = new System.Windows.Forms.ListBox();
            this.refresh_button = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.load_Button = new System.Windows.Forms.Button();
            this.save_Button = new System.Windows.Forms.Button();
            this.addAxis_Button = new System.Windows.Forms.Button();
            this.removeSelected = new System.Windows.Forms.Button();
            this.runEmulationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add a bind";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // controllerListBox
            // 
            this.controllerListBox.FormattingEnabled = true;
            this.controllerListBox.Location = new System.Drawing.Point(93, 12);
            this.controllerListBox.Name = "controllerListBox";
            this.controllerListBox.Size = new System.Drawing.Size(245, 82);
            this.controllerListBox.TabIndex = 1;
            this.controllerListBox.SelectedIndexChanged += new System.EventHandler(this.controllerListBox_SelectedIndexChanged);
            // 
            // refresh_button
            // 
            this.refresh_button.Location = new System.Drawing.Point(12, 12);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(75, 23);
            this.refresh_button.TabIndex = 2;
            this.refresh_button.Text = "Refresh";
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 100);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(245, 342);
            this.listBox1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(263, 422);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(525, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Last Input:";
            // 
            // load_Button
            // 
            this.load_Button.Location = new System.Drawing.Point(12, 71);
            this.load_Button.Name = "load_Button";
            this.load_Button.Size = new System.Drawing.Size(75, 23);
            this.load_Button.TabIndex = 5;
            this.load_Button.Text = "Load config";
            this.load_Button.UseVisualStyleBackColor = true;
            // 
            // save_Button
            // 
            this.save_Button.Location = new System.Drawing.Point(12, 42);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 6;
            this.save_Button.Text = "Save config";
            this.save_Button.UseVisualStyleBackColor = true;
            // 
            // addAxis_Button
            // 
            this.addAxis_Button.Location = new System.Drawing.Point(263, 129);
            this.addAxis_Button.Name = "addAxis_Button";
            this.addAxis_Button.Size = new System.Drawing.Size(75, 23);
            this.addAxis_Button.TabIndex = 7;
            this.addAxis_Button.Text = "Add an axis";
            this.addAxis_Button.UseVisualStyleBackColor = true;
            // 
            // removeSelected
            // 
            this.removeSelected.Location = new System.Drawing.Point(263, 381);
            this.removeSelected.Name = "removeSelected";
            this.removeSelected.Size = new System.Drawing.Size(75, 35);
            this.removeSelected.TabIndex = 11;
            this.removeSelected.Text = "Remove selected";
            this.removeSelected.UseVisualStyleBackColor = true;
            this.removeSelected.Click += new System.EventHandler(this.removeSelected_Click);
            // 
            // runEmulationButton
            // 
            this.runEmulationButton.Location = new System.Drawing.Point(713, 393);
            this.runEmulationButton.Name = "runEmulationButton";
            this.runEmulationButton.Size = new System.Drawing.Size(75, 23);
            this.runEmulationButton.TabIndex = 12;
            this.runEmulationButton.Text = "Run";
            this.runEmulationButton.UseVisualStyleBackColor = true;
            this.runEmulationButton.Click += new System.EventHandler(this.runEmulationButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.runEmulationButton);
            this.Controls.Add(this.removeSelected);
            this.Controls.Add(this.addAxis_Button);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.load_Button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.controllerListBox);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox controllerListBox;
        private System.Windows.Forms.Button refresh_button;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button load_Button;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button addAxis_Button;
        private System.Windows.Forms.Button removeSelected;
        private System.Windows.Forms.Button runEmulationButton;
    }
}

