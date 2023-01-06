namespace HomeWork20
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeOfSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bubbleSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertionSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gnomeSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radixSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bucketSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heapSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shellSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewMassiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mixElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(23, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create new array";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortingToolStripMenuItem,
            this.massiveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1089, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sortingToolStripMenuItem
            // 
            this.sortingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeOfSortToolStripMenuItem,
            this.toolStripSeparator1,
            this.bubbleSortToolStripMenuItem,
            this.selectionSortToolStripMenuItem,
            this.insertionSortToolStripMenuItem,
            this.mergeSortToolStripMenuItem,
            this.quickSortToolStripMenuItem,
            this.gnomeSortToolStripMenuItem,
            this.radixSortToolStripMenuItem,
            this.bucketSortToolStripMenuItem,
            this.heapSortToolStripMenuItem,
            this.shellSortToolStripMenuItem});
            this.sortingToolStripMenuItem.Name = "sortingToolStripMenuItem";
            this.sortingToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.sortingToolStripMenuItem.Text = "Sorting";
            // 
            // typeOfSortToolStripMenuItem
            // 
            this.typeOfSortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decreaseToolStripMenuItem,
            this.increaseToolStripMenuItem});
            this.typeOfSortToolStripMenuItem.Name = "typeOfSortToolStripMenuItem";
            this.typeOfSortToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.typeOfSortToolStripMenuItem.Text = "Type of sort";
            // 
            // decreaseToolStripMenuItem
            // 
            this.decreaseToolStripMenuItem.Checked = true;
            this.decreaseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.decreaseToolStripMenuItem.Name = "decreaseToolStripMenuItem";
            this.decreaseToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.decreaseToolStripMenuItem.Text = "Decrease";
            // 
            // increaseToolStripMenuItem
            // 
            this.increaseToolStripMenuItem.Name = "increaseToolStripMenuItem";
            this.increaseToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.increaseToolStripMenuItem.Text = "Increase";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // bubbleSortToolStripMenuItem
            // 
            this.bubbleSortToolStripMenuItem.Name = "bubbleSortToolStripMenuItem";
            this.bubbleSortToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.bubbleSortToolStripMenuItem.Text = "Bubble Sort";
            // 
            // selectionSortToolStripMenuItem
            // 
            this.selectionSortToolStripMenuItem.Name = "selectionSortToolStripMenuItem";
            this.selectionSortToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.selectionSortToolStripMenuItem.Text = "Selection Sort";
            // 
            // insertionSortToolStripMenuItem
            // 
            this.insertionSortToolStripMenuItem.Name = "insertionSortToolStripMenuItem";
            this.insertionSortToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.insertionSortToolStripMenuItem.Text = "Insertion Sort";
            // 
            // mergeSortToolStripMenuItem
            // 
            this.mergeSortToolStripMenuItem.Name = "mergeSortToolStripMenuItem";
            this.mergeSortToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.mergeSortToolStripMenuItem.Text = "Merge Sort";
            // 
            // quickSortToolStripMenuItem
            // 
            this.quickSortToolStripMenuItem.Name = "quickSortToolStripMenuItem";
            this.quickSortToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.quickSortToolStripMenuItem.Text = "QuickSort";
            // 
            // gnomeSortToolStripMenuItem
            // 
            this.gnomeSortToolStripMenuItem.Name = "gnomeSortToolStripMenuItem";
            this.gnomeSortToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.gnomeSortToolStripMenuItem.Text = "Gnome Sort";
            // 
            // radixSortToolStripMenuItem
            // 
            this.radixSortToolStripMenuItem.Name = "radixSortToolStripMenuItem";
            this.radixSortToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.radixSortToolStripMenuItem.Text = "Radix Sort";
            // 
            // bucketSortToolStripMenuItem
            // 
            this.bucketSortToolStripMenuItem.Name = "bucketSortToolStripMenuItem";
            this.bucketSortToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.bucketSortToolStripMenuItem.Text = "Bucket Sort";
            // 
            // heapSortToolStripMenuItem
            // 
            this.heapSortToolStripMenuItem.Name = "heapSortToolStripMenuItem";
            this.heapSortToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.heapSortToolStripMenuItem.Text = "Heap Sort";
            // 
            // shellSortToolStripMenuItem
            // 
            this.shellSortToolStripMenuItem.Name = "shellSortToolStripMenuItem";
            this.shellSortToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.shellSortToolStripMenuItem.Text = "Shell Sort";
            // 
            // massiveToolStripMenuItem
            // 
            this.massiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewMassiveToolStripMenuItem,
            this.mixElementsToolStripMenuItem});
            this.massiveToolStripMenuItem.Name = "massiveToolStripMenuItem";
            this.massiveToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.massiveToolStripMenuItem.Text = "Array";
            // 
            // createNewMassiveToolStripMenuItem
            // 
            this.createNewMassiveToolStripMenuItem.Name = "createNewMassiveToolStripMenuItem";
            this.createNewMassiveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.createNewMassiveToolStripMenuItem.Text = "Create new array";
            // 
            // mixElementsToolStripMenuItem
            // 
            this.mixElementsToolStripMenuItem.Name = "mixElementsToolStripMenuItem";
            this.mixElementsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.mixElementsToolStripMenuItem.Text = "Mix elements";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(17, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1057, 402);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(17, 449);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 131);
            this.panel1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(135, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(65, 25);
            this.textBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Maximum value:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(65, 25);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amount of elements:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(873, 456);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 63);
            this.button2.TabIndex = 5;
            this.button2.Text = "Mix elements";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(246, 449);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 83);
            this.panel2.TabIndex = 4;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button8.Location = new System.Drawing.Point(480, 44);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 26);
            this.button8.TabIndex = 15;
            this.button8.Text = "Gnome Sort";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button9.Location = new System.Drawing.Point(362, 45);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(100, 26);
            this.button9.TabIndex = 14;
            this.button9.Text = "Radix Sort";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button10.Location = new System.Drawing.Point(245, 45);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 26);
            this.button10.TabIndex = 13;
            this.button10.Text = "Bucket Sort";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button11.Location = new System.Drawing.Point(129, 45);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(100, 26);
            this.button11.TabIndex = 12;
            this.button11.Text = "Heap Sort";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button12.Location = new System.Drawing.Point(14, 45);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(100, 26);
            this.button12.TabIndex = 11;
            this.button12.Text = "Shell Sort";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button7.Location = new System.Drawing.Point(479, 7);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 26);
            this.button7.TabIndex = 10;
            this.button7.Text = "QuickSort";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button6.Location = new System.Drawing.Point(361, 8);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 26);
            this.button6.TabIndex = 9;
            this.button6.Text = "Merge Sort";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(244, 8);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 26);
            this.button5.TabIndex = 8;
            this.button5.Text = "Insertion Sort";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(128, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 26);
            this.button4.TabIndex = 7;
            this.button4.Text = "Selection Sort";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(13, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 26);
            this.button3.TabIndex = 6;
            this.button3.Text = "Bubble Sort";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 592);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sortingToolStripMenuItem;
        private ToolStripMenuItem typeOfSortToolStripMenuItem;
        private ToolStripMenuItem decreaseToolStripMenuItem;
        private ToolStripMenuItem increaseToolStripMenuItem;
        private ToolStripMenuItem massiveToolStripMenuItem;
        private ToolStripMenuItem createNewMassiveToolStripMenuItem;
        private ToolStripMenuItem mixElementsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem bubbleSortToolStripMenuItem;
        private ToolStripMenuItem selectionSortToolStripMenuItem;
        private ToolStripMenuItem insertionSortToolStripMenuItem;
        private ToolStripMenuItem mergeSortToolStripMenuItem;
        private ToolStripMenuItem quickSortToolStripMenuItem;
        private ToolStripMenuItem gnomeSortToolStripMenuItem;
        private ToolStripMenuItem radixSortToolStripMenuItem;
        private ToolStripMenuItem bucketSortToolStripMenuItem;
        private ToolStripMenuItem heapSortToolStripMenuItem;
        private ToolStripMenuItem shellSortToolStripMenuItem;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Button button2;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Panel panel2;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
    }
}