
namespace FileNameChange
{
	partial class MainWindow
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Metoda wymagana do obsługi projektanta — nie należy modyfikować
		/// jej zawartości w edytorze kodu.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.ChListFiles = new System.Windows.Forms.CheckedListBox();
			this.ChSelectAll = new System.Windows.Forms.CheckBox();
			this.TxtNewName = new System.Windows.Forms.TextBox();
			this.TxtPrefix = new System.Windows.Forms.TextBox();
			this.TxtSuffix = new System.Windows.Forms.TextBox();
			this.TxtRepleaceAllOld = new System.Windows.Forms.TextBox();
			this.TxtRepleaceAllNew = new System.Windows.Forms.TextBox();
			this.LbRepleaceAllOld = new System.Windows.Forms.Label();
			this.LbRepleaceAllNew = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.TxtReplaceSelectedNew = new System.Windows.Forms.TextBox();
			this.TxtReplaceSelectedOld = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.RbToUpperCase = new System.Windows.Forms.RadioButton();
			this.RbReplaceSelected = new System.Windows.Forms.RadioButton();
			this.RbRepleaceAll = new System.Windows.Forms.RadioButton();
			this.RbNewName = new System.Windows.Forms.RadioButton();
			this.RbToLowerCase = new System.Windows.Forms.RadioButton();
			this.RbPrefix = new System.Windows.Forms.RadioButton();
			this.RbSuffix = new System.Windows.Forms.RadioButton();
			this.NumReplaceSelectedIndex = new System.Windows.Forms.NumericUpDown();
			this.RbDeleteNumbers = new System.Windows.Forms.RadioButton();
			this.RbDeleteLetters = new System.Windows.Forms.RadioButton();
			this.RbDeleteWhiteSpace = new System.Windows.Forms.RadioButton();
			this.RbDeleteChars = new System.Windows.Forms.RadioButton();
			this.RbDeleteChar = new System.Windows.Forms.RadioButton();
			this.NumDeleteChar = new System.Windows.Forms.NumericUpDown();
			this.RbDeleteFewChars = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.NumDeleteFewCharsNumber = new System.Windows.Forms.NumericUpDown();
			this.NumDeleteFewCharsStart = new System.Windows.Forms.NumericUpDown();
			this.RbAddNumbering = new System.Windows.Forms.RadioButton();
			this.PAddNumbering = new System.Windows.Forms.Panel();
			this.RbAddNumberingEnd = new System.Windows.Forms.RadioButton();
			this.RbAddNumberingStart = new System.Windows.Forms.RadioButton();
			this.TxtAddNumbering = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.NumAddNumberingInc = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.NumAddNumberingStart = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.RbDeleteLastChar = new System.Windows.Forms.RadioButton();
			this.RbDeleteLastChars = new System.Windows.Forms.RadioButton();
			this.NumDeleteLastChars = new System.Windows.Forms.NumericUpDown();
			this.lblDragDrop = new System.Windows.Forms.Label();
			this.BtnClear = new System.Windows.Forms.Button();
			this.BtnChooseDirectory = new System.Windows.Forms.Button();
			this.BtnChangeName = new System.Windows.Forms.Button();
			this.RbFirstToLowerCase = new System.Windows.Forms.RadioButton();
			this.RbFirstToUpperCase = new System.Windows.Forms.RadioButton();
			this.BtnRefresh = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.NumReplaceSelectedIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumDeleteChar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumDeleteFewCharsNumber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumDeleteFewCharsStart)).BeginInit();
			this.PAddNumbering.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumAddNumberingInc)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumAddNumberingStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumDeleteLastChars)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.SelectedPath = "D:\\Muzyka\\dzwonki — kopia";
			// 
			// ChListFiles
			// 
			this.ChListFiles.AllowDrop = true;
			this.ChListFiles.CheckOnClick = true;
			this.ChListFiles.FormattingEnabled = true;
			this.ChListFiles.HorizontalScrollbar = true;
			this.ChListFiles.Location = new System.Drawing.Point(12, 102);
			this.ChListFiles.Name = "ChListFiles";
			this.ChListFiles.Size = new System.Drawing.Size(315, 409);
			this.ChListFiles.TabIndex = 2;
			this.ChListFiles.SelectedIndexChanged += new System.EventHandler(this.ChListFiles_SelectedIndexChanged);
			this.ChListFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.ChListFiles_DragDrop);
			this.ChListFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.ChListFiles_DragEnter);
			// 
			// ChSelectAll
			// 
			this.ChSelectAll.AutoSize = true;
			this.ChSelectAll.Location = new System.Drawing.Point(12, 79);
			this.ChSelectAll.Name = "ChSelectAll";
			this.ChSelectAll.Size = new System.Drawing.Size(160, 17);
			this.ChSelectAll.TabIndex = 3;
			this.ChSelectAll.Text = "Zaznacz/odznacz wszystkie";
			this.ChSelectAll.UseVisualStyleBackColor = true;
			this.ChSelectAll.CheckedChanged += new System.EventHandler(this.ChSelectAll_CheckedChanged);
			// 
			// TxtNewName
			// 
			this.TxtNewName.Location = new System.Drawing.Point(467, 77);
			this.TxtNewName.Name = "TxtNewName";
			this.TxtNewName.Size = new System.Drawing.Size(189, 20);
			this.TxtNewName.TabIndex = 5;
			this.TxtNewName.TextChanged += new System.EventHandler(this.TxtNewName_TextChanged);
			// 
			// TxtPrefix
			// 
			this.TxtPrefix.Location = new System.Drawing.Point(467, 117);
			this.TxtPrefix.Name = "TxtPrefix";
			this.TxtPrefix.Size = new System.Drawing.Size(189, 20);
			this.TxtPrefix.TabIndex = 11;
			this.TxtPrefix.TextChanged += new System.EventHandler(this.TxtPrefix_TextChanged);
			// 
			// TxtSuffix
			// 
			this.TxtSuffix.Location = new System.Drawing.Point(467, 143);
			this.TxtSuffix.Name = "TxtSuffix";
			this.TxtSuffix.Size = new System.Drawing.Size(189, 20);
			this.TxtSuffix.TabIndex = 14;
			this.TxtSuffix.TextChanged += new System.EventHandler(this.TxtSuffix_TextChanged);
			// 
			// TxtRepleaceAllOld
			// 
			this.TxtRepleaceAllOld.Location = new System.Drawing.Point(467, 212);
			this.TxtRepleaceAllOld.Name = "TxtRepleaceAllOld";
			this.TxtRepleaceAllOld.Size = new System.Drawing.Size(189, 20);
			this.TxtRepleaceAllOld.TabIndex = 17;
			this.TxtRepleaceAllOld.TextChanged += new System.EventHandler(this.TxtRepleaceAllTextChanged);
			// 
			// TxtRepleaceAllNew
			// 
			this.TxtRepleaceAllNew.Location = new System.Drawing.Point(467, 238);
			this.TxtRepleaceAllNew.Name = "TxtRepleaceAllNew";
			this.TxtRepleaceAllNew.Size = new System.Drawing.Size(189, 20);
			this.TxtRepleaceAllNew.TabIndex = 19;
			this.TxtRepleaceAllNew.TextChanged += new System.EventHandler(this.TxtRepleaceAllTextChanged);
			// 
			// LbRepleaceAllOld
			// 
			this.LbRepleaceAllOld.AutoSize = true;
			this.LbRepleaceAllOld.Location = new System.Drawing.Point(355, 215);
			this.LbRepleaceAllOld.Name = "LbRepleaceAllOld";
			this.LbRepleaceAllOld.Size = new System.Drawing.Size(107, 13);
			this.LbRepleaceAllOld.TabIndex = 20;
			this.LbRepleaceAllOld.Text = "Szukany znak/znaki:";
			// 
			// LbRepleaceAllNew
			// 
			this.LbRepleaceAllNew.AutoSize = true;
			this.LbRepleaceAllNew.Location = new System.Drawing.Point(355, 241);
			this.LbRepleaceAllNew.Name = "LbRepleaceAllNew";
			this.LbRepleaceAllNew.Size = new System.Drawing.Size(93, 13);
			this.LbRepleaceAllNew.TabIndex = 21;
			this.LbRepleaceAllNew.Text = "Nowy znak/znaki:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(355, 330);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 26;
			this.label3.Text = "Nowy znak:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(355, 304);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 13);
			this.label4.TabIndex = 25;
			this.label4.Text = "Szukany znak:";
			// 
			// TxtReplaceSelectedNew
			// 
			this.TxtReplaceSelectedNew.Location = new System.Drawing.Point(467, 327);
			this.TxtReplaceSelectedNew.MaxLength = 1;
			this.TxtReplaceSelectedNew.Name = "TxtReplaceSelectedNew";
			this.TxtReplaceSelectedNew.Size = new System.Drawing.Size(189, 20);
			this.TxtReplaceSelectedNew.TabIndex = 24;
			this.TxtReplaceSelectedNew.TextChanged += new System.EventHandler(this.NumReplaceSelectedValueChanged);
			// 
			// TxtReplaceSelectedOld
			// 
			this.TxtReplaceSelectedOld.Location = new System.Drawing.Point(467, 301);
			this.TxtReplaceSelectedOld.MaxLength = 1;
			this.TxtReplaceSelectedOld.Name = "TxtReplaceSelectedOld";
			this.TxtReplaceSelectedOld.Size = new System.Drawing.Size(189, 20);
			this.TxtReplaceSelectedOld.TabIndex = 23;
			this.TxtReplaceSelectedOld.TextChanged += new System.EventHandler(this.NumReplaceSelectedValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(355, 355);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(99, 13);
			this.label5.TabIndex = 27;
			this.label5.Text = "Numer wystąpienia:";
			// 
			// RbToUpperCase
			// 
			this.RbToUpperCase.AutoSize = true;
			this.RbToUpperCase.Location = new System.Drawing.Point(694, 78);
			this.RbToUpperCase.Name = "RbToUpperCase";
			this.RbToUpperCase.Size = new System.Drawing.Size(134, 17);
			this.RbToUpperCase.TabIndex = 29;
			this.RbToUpperCase.TabStop = true;
			this.RbToUpperCase.Text = "Zamień na wielkie litery";
			this.RbToUpperCase.UseVisualStyleBackColor = true;
			// 
			// RbReplaceSelected
			// 
			this.RbReplaceSelected.AutoSize = true;
			this.RbReplaceSelected.Location = new System.Drawing.Point(358, 276);
			this.RbReplaceSelected.Name = "RbReplaceSelected";
			this.RbReplaceSelected.Size = new System.Drawing.Size(103, 17);
			this.RbReplaceSelected.TabIndex = 30;
			this.RbReplaceSelected.TabStop = true;
			this.RbReplaceSelected.Text = "Zastąp wybrany:";
			this.RbReplaceSelected.UseVisualStyleBackColor = true;
			// 
			// RbRepleaceAll
			// 
			this.RbRepleaceAll.AutoSize = true;
			this.RbRepleaceAll.Location = new System.Drawing.Point(358, 189);
			this.RbRepleaceAll.Name = "RbRepleaceAll";
			this.RbRepleaceAll.Size = new System.Drawing.Size(167, 17);
			this.RbRepleaceAll.TabIndex = 31;
			this.RbRepleaceAll.TabStop = true;
			this.RbRepleaceAll.Text = "Zastąp wszystkie wystąpienia:";
			this.RbRepleaceAll.UseVisualStyleBackColor = true;
			// 
			// RbNewName
			// 
			this.RbNewName.AutoSize = true;
			this.RbNewName.Location = new System.Drawing.Point(358, 79);
			this.RbNewName.Name = "RbNewName";
			this.RbNewName.Size = new System.Drawing.Size(90, 17);
			this.RbNewName.TabIndex = 32;
			this.RbNewName.TabStop = true;
			this.RbNewName.Text = "Nowa nazwa:";
			this.RbNewName.UseVisualStyleBackColor = true;
			// 
			// RbToLowerCase
			// 
			this.RbToLowerCase.AutoSize = true;
			this.RbToLowerCase.Location = new System.Drawing.Point(694, 101);
			this.RbToLowerCase.Name = "RbToLowerCase";
			this.RbToLowerCase.Size = new System.Drawing.Size(126, 17);
			this.RbToLowerCase.TabIndex = 33;
			this.RbToLowerCase.TabStop = true;
			this.RbToLowerCase.Text = "Zamień na małe litery";
			this.RbToLowerCase.UseVisualStyleBackColor = true;
			// 
			// RbPrefix
			// 
			this.RbPrefix.AutoSize = true;
			this.RbPrefix.Location = new System.Drawing.Point(358, 117);
			this.RbPrefix.Name = "RbPrefix";
			this.RbPrefix.Size = new System.Drawing.Size(84, 17);
			this.RbPrefix.TabIndex = 36;
			this.RbPrefix.TabStop = true;
			this.RbPrefix.Text = "Przedrostek:";
			this.RbPrefix.UseVisualStyleBackColor = true;
			// 
			// RbSuffix
			// 
			this.RbSuffix.AutoSize = true;
			this.RbSuffix.Location = new System.Drawing.Point(358, 144);
			this.RbSuffix.Name = "RbSuffix";
			this.RbSuffix.Size = new System.Drawing.Size(77, 17);
			this.RbSuffix.TabIndex = 37;
			this.RbSuffix.TabStop = true;
			this.RbSuffix.Text = "Przyrostek:";
			this.RbSuffix.UseVisualStyleBackColor = true;
			// 
			// NumReplaceSelectedIndex
			// 
			this.NumReplaceSelectedIndex.Location = new System.Drawing.Point(467, 353);
			this.NumReplaceSelectedIndex.Name = "NumReplaceSelectedIndex";
			this.NumReplaceSelectedIndex.Size = new System.Drawing.Size(189, 20);
			this.NumReplaceSelectedIndex.TabIndex = 38;
			this.NumReplaceSelectedIndex.ValueChanged += new System.EventHandler(this.NumReplaceSelectedValueChanged);
			// 
			// RbDeleteNumbers
			// 
			this.RbDeleteNumbers.AutoSize = true;
			this.RbDeleteNumbers.Location = new System.Drawing.Point(694, 190);
			this.RbDeleteNumbers.Name = "RbDeleteNumbers";
			this.RbDeleteNumbers.Size = new System.Drawing.Size(123, 17);
			this.RbDeleteNumbers.TabIndex = 40;
			this.RbDeleteNumbers.TabStop = true;
			this.RbDeleteNumbers.Text = "Usuń wszystkie cyfry";
			this.RbDeleteNumbers.UseVisualStyleBackColor = true;
			// 
			// RbDeleteLetters
			// 
			this.RbDeleteLetters.AutoSize = true;
			this.RbDeleteLetters.Location = new System.Drawing.Point(694, 213);
			this.RbDeleteLetters.Name = "RbDeleteLetters";
			this.RbDeleteLetters.Size = new System.Drawing.Size(122, 17);
			this.RbDeleteLetters.TabIndex = 41;
			this.RbDeleteLetters.TabStop = true;
			this.RbDeleteLetters.Text = "Usuń wszystkie litery";
			this.RbDeleteLetters.UseVisualStyleBackColor = true;
			// 
			// RbDeleteWhiteSpace
			// 
			this.RbDeleteWhiteSpace.AutoSize = true;
			this.RbDeleteWhiteSpace.Location = new System.Drawing.Point(694, 236);
			this.RbDeleteWhiteSpace.Name = "RbDeleteWhiteSpace";
			this.RbDeleteWhiteSpace.Size = new System.Drawing.Size(153, 17);
			this.RbDeleteWhiteSpace.TabIndex = 42;
			this.RbDeleteWhiteSpace.TabStop = true;
			this.RbDeleteWhiteSpace.Text = "Usuń wszystkie białe znaki";
			this.RbDeleteWhiteSpace.UseVisualStyleBackColor = true;
			// 
			// RbDeleteChars
			// 
			this.RbDeleteChars.AutoSize = true;
			this.RbDeleteChars.Location = new System.Drawing.Point(694, 259);
			this.RbDeleteChars.Name = "RbDeleteChars";
			this.RbDeleteChars.Size = new System.Drawing.Size(176, 17);
			this.RbDeleteChars.TabIndex = 43;
			this.RbDeleteChars.TabStop = true;
			this.RbDeleteChars.Text = "Usuń wszystkie pozostałe znaki";
			this.RbDeleteChars.UseVisualStyleBackColor = true;
			// 
			// RbDeleteChar
			// 
			this.RbDeleteChar.AutoSize = true;
			this.RbDeleteChar.Location = new System.Drawing.Point(694, 301);
			this.RbDeleteChar.Name = "RbDeleteChar";
			this.RbDeleteChar.Size = new System.Drawing.Size(129, 17);
			this.RbDeleteChar.TabIndex = 44;
			this.RbDeleteChar.TabStop = true;
			this.RbDeleteChar.Text = "Usuń znak na pozycji:";
			this.RbDeleteChar.UseVisualStyleBackColor = true;
			// 
			// NumDeleteChar
			// 
			this.NumDeleteChar.Location = new System.Drawing.Point(822, 301);
			this.NumDeleteChar.Name = "NumDeleteChar";
			this.NumDeleteChar.Size = new System.Drawing.Size(60, 20);
			this.NumDeleteChar.TabIndex = 45;
			this.NumDeleteChar.ValueChanged += new System.EventHandler(this.NumDeleteChar_ValueChanged);
			// 
			// RbDeleteFewChars
			// 
			this.RbDeleteFewChars.AutoSize = true;
			this.RbDeleteFewChars.Location = new System.Drawing.Point(694, 340);
			this.RbDeleteFewChars.Name = "RbDeleteFewChars";
			this.RbDeleteFewChars.Size = new System.Drawing.Size(118, 17);
			this.RbDeleteFewChars.TabIndex = 47;
			this.RbDeleteFewChars.TabStop = true;
			this.RbDeleteFewChars.Text = "Usuń kilka znaków:";
			this.RbDeleteFewChars.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(713, 392);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 48;
			this.label1.Text = "Ilość znaków:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(713, 366);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 13);
			this.label2.TabIndex = 49;
			this.label2.Text = "Pozycja startowa:";
			// 
			// NumDeleteFewCharsNumber
			// 
			this.NumDeleteFewCharsNumber.Location = new System.Drawing.Point(822, 390);
			this.NumDeleteFewCharsNumber.Name = "NumDeleteFewCharsNumber";
			this.NumDeleteFewCharsNumber.Size = new System.Drawing.Size(60, 20);
			this.NumDeleteFewCharsNumber.TabIndex = 50;
			this.NumDeleteFewCharsNumber.ValueChanged += new System.EventHandler(this.NumDeleteFewCharsValueChanged);
			// 
			// NumDeleteFewCharsStart
			// 
			this.NumDeleteFewCharsStart.Location = new System.Drawing.Point(822, 364);
			this.NumDeleteFewCharsStart.Name = "NumDeleteFewCharsStart";
			this.NumDeleteFewCharsStart.Size = new System.Drawing.Size(60, 20);
			this.NumDeleteFewCharsStart.TabIndex = 51;
			this.NumDeleteFewCharsStart.ValueChanged += new System.EventHandler(this.NumDeleteFewCharsValueChanged);
			// 
			// RbAddNumbering
			// 
			this.RbAddNumbering.AutoSize = true;
			this.RbAddNumbering.Location = new System.Drawing.Point(358, 399);
			this.RbAddNumbering.Name = "RbAddNumbering";
			this.RbAddNumbering.Size = new System.Drawing.Size(108, 17);
			this.RbAddNumbering.TabIndex = 52;
			this.RbAddNumbering.TabStop = true;
			this.RbAddNumbering.Text = "Dodaj numerację:";
			this.RbAddNumbering.UseVisualStyleBackColor = true;
			this.RbAddNumbering.CheckedChanged += new System.EventHandler(this.RbAddNumbering_CheckedChanged);
			// 
			// PAddNumbering
			// 
			this.PAddNumbering.Controls.Add(this.RbAddNumberingEnd);
			this.PAddNumbering.Controls.Add(this.RbAddNumberingStart);
			this.PAddNumbering.Controls.Add(this.TxtAddNumbering);
			this.PAddNumbering.Controls.Add(this.label8);
			this.PAddNumbering.Controls.Add(this.NumAddNumberingInc);
			this.PAddNumbering.Controls.Add(this.label7);
			this.PAddNumbering.Controls.Add(this.NumAddNumberingStart);
			this.PAddNumbering.Controls.Add(this.label6);
			this.PAddNumbering.Location = new System.Drawing.Point(358, 422);
			this.PAddNumbering.Name = "PAddNumbering";
			this.PAddNumbering.Size = new System.Drawing.Size(298, 89);
			this.PAddNumbering.TabIndex = 53;
			// 
			// RbAddNumberingEnd
			// 
			this.RbAddNumberingEnd.AutoSize = true;
			this.RbAddNumberingEnd.Location = new System.Drawing.Point(106, 3);
			this.RbAddNumberingEnd.Name = "RbAddNumberingEnd";
			this.RbAddNumberingEnd.Size = new System.Drawing.Size(72, 17);
			this.RbAddNumberingEnd.TabIndex = 58;
			this.RbAddNumberingEnd.TabStop = true;
			this.RbAddNumberingEnd.Text = "Na końcu";
			this.RbAddNumberingEnd.UseVisualStyleBackColor = true;
			this.RbAddNumberingEnd.CheckedChanged += new System.EventHandler(this.RbAddNumberingStartEndCheckedChanged);
			// 
			// RbAddNumberingStart
			// 
			this.RbAddNumberingStart.AutoSize = true;
			this.RbAddNumberingStart.Location = new System.Drawing.Point(3, 3);
			this.RbAddNumberingStart.Name = "RbAddNumberingStart";
			this.RbAddNumberingStart.Size = new System.Drawing.Size(86, 17);
			this.RbAddNumberingStart.TabIndex = 57;
			this.RbAddNumberingStart.TabStop = true;
			this.RbAddNumberingStart.Text = "Na początku";
			this.RbAddNumberingStart.UseVisualStyleBackColor = true;
			this.RbAddNumberingStart.CheckedChanged += new System.EventHandler(this.RbAddNumberingStartEndCheckedChanged);
			// 
			// TxtAddNumbering
			// 
			this.TxtAddNumbering.Location = new System.Drawing.Point(135, 62);
			this.TxtAddNumbering.Name = "TxtAddNumbering";
			this.TxtAddNumbering.Size = new System.Drawing.Size(160, 20);
			this.TxtAddNumbering.TabIndex = 56;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(3, 65);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(126, 13);
			this.label8.TabIndex = 55;
			this.label8.Text = "Znak/tekst rozdzielający:";
			// 
			// NumAddNumberingInc
			// 
			this.NumAddNumberingInc.Location = new System.Drawing.Point(235, 30);
			this.NumAddNumberingInc.Name = "NumAddNumberingInc";
			this.NumAddNumberingInc.Size = new System.Drawing.Size(60, 20);
			this.NumAddNumberingInc.TabIndex = 54;
			this.NumAddNumberingInc.ValueChanged += new System.EventHandler(this.NumAddNumberingValueChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(171, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 13);
			this.label7.TabIndex = 53;
			this.label7.Text = "Zwiększ o:";
			// 
			// NumAddNumberingStart
			// 
			this.NumAddNumberingStart.Location = new System.Drawing.Point(92, 30);
			this.NumAddNumberingStart.Name = "NumAddNumberingStart";
			this.NumAddNumberingStart.Size = new System.Drawing.Size(60, 20);
			this.NumAddNumberingStart.TabIndex = 52;
			this.NumAddNumberingStart.ValueChanged += new System.EventHandler(this.NumAddNumberingValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(83, 13);
			this.label6.TabIndex = 50;
			this.label6.Text = "Numer startowy:";
			// 
			// RbDeleteLastChar
			// 
			this.RbDeleteLastChar.AutoSize = true;
			this.RbDeleteLastChar.Location = new System.Drawing.Point(694, 424);
			this.RbDeleteLastChar.Name = "RbDeleteLastChar";
			this.RbDeleteLastChar.Size = new System.Drawing.Size(110, 17);
			this.RbDeleteLastChar.TabIndex = 54;
			this.RbDeleteLastChar.TabStop = true;
			this.RbDeleteLastChar.Text = "Usuń ostatni znak";
			this.RbDeleteLastChar.UseVisualStyleBackColor = true;
			// 
			// RbDeleteLastChars
			// 
			this.RbDeleteLastChars.AutoSize = true;
			this.RbDeleteLastChars.Location = new System.Drawing.Point(694, 452);
			this.RbDeleteLastChars.Name = "RbDeleteLastChars";
			this.RbDeleteLastChars.Size = new System.Drawing.Size(121, 17);
			this.RbDeleteLastChars.TabIndex = 55;
			this.RbDeleteLastChars.TabStop = true;
			this.RbDeleteLastChars.Text = "Usuń ostatnie znaki:";
			this.RbDeleteLastChars.UseVisualStyleBackColor = true;
			// 
			// NumDeleteLastChars
			// 
			this.NumDeleteLastChars.Location = new System.Drawing.Point(822, 452);
			this.NumDeleteLastChars.Name = "NumDeleteLastChars";
			this.NumDeleteLastChars.Size = new System.Drawing.Size(60, 20);
			this.NumDeleteLastChars.TabIndex = 56;
			this.NumDeleteLastChars.ValueChanged += new System.EventHandler(this.NumDeleteLastChars_ValueChanged);
			// 
			// lblDragDrop
			// 
			this.lblDragDrop.AutoSize = true;
			this.lblDragDrop.BackColor = System.Drawing.Color.White;
			this.lblDragDrop.Location = new System.Drawing.Point(98, 304);
			this.lblDragDrop.Name = "lblDragDrop";
			this.lblDragDrop.Size = new System.Drawing.Size(129, 13);
			this.lblDragDrop.TabIndex = 57;
			this.lblDragDrop.Text = "< Przeciągnij pliki tutaj... >";
			// 
			// BtnClear
			// 
			this.BtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnClear.Enabled = false;
			this.BtnClear.Image = global::FileNameChange.Properties.Resources.IconClearSmall;
			this.BtnClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.BtnClear.Location = new System.Drawing.Point(200, 0);
			this.BtnClear.Margin = new System.Windows.Forms.Padding(0);
			this.BtnClear.Name = "BtnClear";
			this.BtnClear.Size = new System.Drawing.Size(100, 56);
			this.BtnClear.TabIndex = 11;
			this.BtnClear.Text = "Wyczyść";
			this.BtnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.BtnClear.UseVisualStyleBackColor = true;
			this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
			// 
			// BtnChooseDirectory
			// 
			this.BtnChooseDirectory.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.BtnChooseDirectory.Image = global::FileNameChange.Properties.Resources.IconOpenFolderSmall;
			this.BtnChooseDirectory.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.BtnChooseDirectory.Location = new System.Drawing.Point(0, 0);
			this.BtnChooseDirectory.Margin = new System.Windows.Forms.Padding(0);
			this.BtnChooseDirectory.Name = "BtnChooseDirectory";
			this.BtnChooseDirectory.Size = new System.Drawing.Size(100, 56);
			this.BtnChooseDirectory.TabIndex = 0;
			this.BtnChooseDirectory.Text = "Wybierz folder...";
			this.BtnChooseDirectory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.BtnChooseDirectory.UseVisualStyleBackColor = true;
			this.BtnChooseDirectory.Click += new System.EventHandler(this.BtnChooseDirectory_Click);
			// 
			// BtnChangeName
			// 
			this.BtnChangeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnChangeName.Enabled = false;
			this.BtnChangeName.Image = global::FileNameChange.Properties.Resources.IconBtnChangeNameSmall;
			this.BtnChangeName.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.BtnChangeName.Location = new System.Drawing.Point(100, 0);
			this.BtnChangeName.Margin = new System.Windows.Forms.Padding(0);
			this.BtnChangeName.Name = "BtnChangeName";
			this.BtnChangeName.Size = new System.Drawing.Size(100, 56);
			this.BtnChangeName.TabIndex = 10;
			this.BtnChangeName.Text = "Zmień nazwę";
			this.BtnChangeName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.BtnChangeName.UseVisualStyleBackColor = true;
			this.BtnChangeName.Click += new System.EventHandler(this.BtnChangeName_Click);
			// 
			// RbFirstToLowerCase
			// 
			this.RbFirstToLowerCase.AutoSize = true;
			this.RbFirstToLowerCase.Location = new System.Drawing.Point(694, 147);
			this.RbFirstToLowerCase.Name = "RbFirstToLowerCase";
			this.RbFirstToLowerCase.Size = new System.Drawing.Size(195, 17);
			this.RbFirstToLowerCase.TabIndex = 60;
			this.RbFirstToLowerCase.TabStop = true;
			this.RbFirstToLowerCase.Text = "Zamień pierwszy znak na małe litery";
			this.RbFirstToLowerCase.UseVisualStyleBackColor = true;
			// 
			// RbFirstToUpperCase
			// 
			this.RbFirstToUpperCase.AutoSize = true;
			this.RbFirstToUpperCase.Location = new System.Drawing.Point(694, 124);
			this.RbFirstToUpperCase.Name = "RbFirstToUpperCase";
			this.RbFirstToUpperCase.Size = new System.Drawing.Size(203, 17);
			this.RbFirstToUpperCase.TabIndex = 59;
			this.RbFirstToUpperCase.TabStop = true;
			this.RbFirstToUpperCase.Text = "Zamień pierwszy znak na wielkie litery";
			this.RbFirstToUpperCase.UseVisualStyleBackColor = true;
			// 
			// BtnRefresh
			// 
			this.BtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnRefresh.Enabled = false;
			this.BtnRefresh.Image = global::FileNameChange.Properties.Resources.IconRefreshSmall;
			this.BtnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.BtnRefresh.Location = new System.Drawing.Point(300, 0);
			this.BtnRefresh.Margin = new System.Windows.Forms.Padding(0);
			this.BtnRefresh.Name = "BtnRefresh";
			this.BtnRefresh.Size = new System.Drawing.Size(100, 56);
			this.BtnRefresh.TabIndex = 12;
			this.BtnRefresh.Text = "Odśwież";
			this.BtnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.BtnRefresh.UseVisualStyleBackColor = true;
			this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.BtnChooseDirectory);
			this.flowLayoutPanel1.Controls.Add(this.BtnChangeName);
			this.flowLayoutPanel1.Controls.Add(this.BtnClear);
			this.flowLayoutPanel1.Controls.Add(this.BtnRefresh);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 6);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(652, 62);
			this.flowLayoutPanel1.TabIndex = 61;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(909, 522);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.RbFirstToLowerCase);
			this.Controls.Add(this.RbFirstToUpperCase);
			this.Controls.Add(this.lblDragDrop);
			this.Controls.Add(this.NumDeleteLastChars);
			this.Controls.Add(this.RbDeleteLastChars);
			this.Controls.Add(this.RbDeleteLastChar);
			this.Controls.Add(this.PAddNumbering);
			this.Controls.Add(this.RbAddNumbering);
			this.Controls.Add(this.NumDeleteFewCharsStart);
			this.Controls.Add(this.NumDeleteFewCharsNumber);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.RbDeleteFewChars);
			this.Controls.Add(this.NumDeleteChar);
			this.Controls.Add(this.RbDeleteChar);
			this.Controls.Add(this.RbDeleteChars);
			this.Controls.Add(this.RbDeleteWhiteSpace);
			this.Controls.Add(this.RbDeleteLetters);
			this.Controls.Add(this.RbDeleteNumbers);
			this.Controls.Add(this.NumReplaceSelectedIndex);
			this.Controls.Add(this.RbSuffix);
			this.Controls.Add(this.RbPrefix);
			this.Controls.Add(this.RbToLowerCase);
			this.Controls.Add(this.RbNewName);
			this.Controls.Add(this.RbRepleaceAll);
			this.Controls.Add(this.RbReplaceSelected);
			this.Controls.Add(this.RbToUpperCase);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.TxtReplaceSelectedNew);
			this.Controls.Add(this.TxtReplaceSelectedOld);
			this.Controls.Add(this.LbRepleaceAllNew);
			this.Controls.Add(this.LbRepleaceAllOld);
			this.Controls.Add(this.TxtRepleaceAllNew);
			this.Controls.Add(this.TxtRepleaceAllOld);
			this.Controls.Add(this.TxtSuffix);
			this.Controls.Add(this.TxtPrefix);
			this.Controls.Add(this.TxtNewName);
			this.Controls.Add(this.ChSelectAll);
			this.Controls.Add(this.ChListFiles);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "File name change";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.NumReplaceSelectedIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumDeleteChar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumDeleteFewCharsNumber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumDeleteFewCharsStart)).EndInit();
			this.PAddNumbering.ResumeLayout(false);
			this.PAddNumbering.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumAddNumberingInc)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumAddNumberingStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumDeleteLastChars)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button BtnChooseDirectory;
		private System.Windows.Forms.CheckedListBox ChListFiles;
		private System.Windows.Forms.CheckBox ChSelectAll;
		private System.Windows.Forms.TextBox TxtNewName;
		private System.Windows.Forms.Button BtnChangeName;
		private System.Windows.Forms.TextBox TxtPrefix;
		private System.Windows.Forms.TextBox TxtSuffix;
		private System.Windows.Forms.TextBox TxtRepleaceAllOld;
		private System.Windows.Forms.TextBox TxtRepleaceAllNew;
		private System.Windows.Forms.Label LbRepleaceAllOld;
		private System.Windows.Forms.Label LbRepleaceAllNew;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox TxtReplaceSelectedNew;
		private System.Windows.Forms.TextBox TxtReplaceSelectedOld;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RadioButton RbToUpperCase;
		private System.Windows.Forms.RadioButton RbReplaceSelected;
		private System.Windows.Forms.RadioButton RbRepleaceAll;
		private System.Windows.Forms.RadioButton RbNewName;
		private System.Windows.Forms.RadioButton RbToLowerCase;
		private System.Windows.Forms.RadioButton RbPrefix;
		private System.Windows.Forms.RadioButton RbSuffix;
		private System.Windows.Forms.NumericUpDown NumReplaceSelectedIndex;
		private System.Windows.Forms.RadioButton RbDeleteNumbers;
		private System.Windows.Forms.RadioButton RbDeleteLetters;
		private System.Windows.Forms.RadioButton RbDeleteWhiteSpace;
		private System.Windows.Forms.RadioButton RbDeleteChars;
		private System.Windows.Forms.RadioButton RbDeleteChar;
		private System.Windows.Forms.NumericUpDown NumDeleteChar;
		private System.Windows.Forms.RadioButton RbDeleteFewChars;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown NumDeleteFewCharsNumber;
		private System.Windows.Forms.NumericUpDown NumDeleteFewCharsStart;
		private System.Windows.Forms.RadioButton RbAddNumbering;
		private System.Windows.Forms.Panel PAddNumbering;
		private System.Windows.Forms.RadioButton RbAddNumberingEnd;
		private System.Windows.Forms.RadioButton RbAddNumberingStart;
		private System.Windows.Forms.TextBox TxtAddNumbering;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown NumAddNumberingInc;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown NumAddNumberingStart;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton RbDeleteLastChar;
		private System.Windows.Forms.RadioButton RbDeleteLastChars;
		private System.Windows.Forms.NumericUpDown NumDeleteLastChars;
		private System.Windows.Forms.Label lblDragDrop;
		private System.Windows.Forms.Button BtnClear;
		private System.Windows.Forms.RadioButton RbFirstToLowerCase;
		private System.Windows.Forms.RadioButton RbFirstToUpperCase;
		private System.Windows.Forms.Button BtnRefresh;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}

