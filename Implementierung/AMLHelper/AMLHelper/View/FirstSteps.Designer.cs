using System.Windows.Forms;
namespace AMLHelper.View
{
    partial class FirstSteps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstSteps));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beginnen Sie wie folgt:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 145);
            this.label2.TabIndex = 1;
            this.label2.Text = "1. Öffnen Sie über das Menu \"Datei\" > \"Öffnen\" eine gültige AML-Datei mit einer S" +
    "ystemUnitClassLibrary und ggf. bestehenden Instanzhierarchien.";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(345, 136);
            this.label3.TabIndex = 2;
            this.label3.Text = "2. In der Baumansicht links erscheinen bestehende Instanzhierarchien mit ihrem Na" +
    "men. Fügen Sie ggf. über das Menü \"Bearbeiten\" > \"Neue Instanzhierachie anlegen\"" +
    " eine neue Instanzhierarchie ein.";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(346, 144);
            this.label4.TabIndex = 3;
            this.label4.Text = "3. Öffnen Sie eine Instanzhierarchie durch einen Doppelklick auf den Namen links " +
    "in der Baumansicht. Sie öffnet sich in einer Registerkarte.";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(345, 135);
            this.label5.TabIndex = 4;
            this.label5.Text = "4. Bearbeiten Sie ggf. den Namen und fügen neue InternalElements hinzu, indem Sie" +
    " den gewünschten Typ in der Liste auswählen und auf \"Hinzufügen\" klicken.";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(345, 126);
            this.label6.TabIndex = 5;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 379);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(345, 133);
            this.label7.TabIndex = 6;
            this.label7.Text = "6. Haben Sie das Modell erstellt, schließen Sie Ihre Arbeit ab, indem Sie über da" +
    "s Menü \"Datei\" > \"Speichern\" abspeichern.";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 447);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(345, 133);
            this.label8.TabIndex = 7;
            this.label8.Text = "Weitere Informationen zum Einstieg in AutomationML finden Sie ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(0, 4);
            this.linkLabel1.Location = new System.Drawing.Point(75, 463);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(30, 17);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "hier";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // FirstSteps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(370, 495);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FirstSteps";
            this.Text = "Erste Schritte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}