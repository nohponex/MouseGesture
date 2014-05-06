namespace MouseGesturesProject {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.gesturesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Right click to start capture - Right click to stop";
            // 
            // gesturesLabel
            // 
            this.gesturesLabel.AutoSize = true;
            this.gesturesLabel.Location = new System.Drawing.Point(12, 9);
            this.gesturesLabel.Name = "gesturesLabel";
            this.gesturesLabel.Size = new System.Drawing.Size(89, 13);
            this.gesturesLabel.TabIndex = 1;
            this.gesturesLabel.Text = "Demo Gestures : ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 516);
            this.Controls.Add(this.gesturesLabel);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Demo form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label gesturesLabel;
    }
}

