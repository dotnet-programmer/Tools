using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FileNameChange
{
	public partial class MainWindow : Form
	{
		private const string defaultLabel = "Wybrany folder: ";

		FileNameChange fileNameChange = new FileNameChange();

		private bool isMultiselect;
		private bool isChecked;
		private int multiselectStartIndex;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void BtnChooseDirectory_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				string selectedPath;
				try
				{
					selectedPath = folderBrowserDialog1.SelectedPath;
					FillChListFiles(Directory.GetFiles(selectedPath));
					//lblDragDrop.Visible = false;
					//BtnChangeName.Enabled = BtnClear.Enabled = BtnRefresh.Enabled = ChListFiles.Items.Count > 0 ? true : false;
				}
				catch (InvalidOperationException ex)
				{
					selectedPath = string.Empty;
					MessageBox.Show(ex.Message, "Błąd otwarcia folderu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ChSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < ChListFiles.Items.Count; i++)
				ChListFiles.SetItemChecked(i, ChSelectAll.Checked);
		}

		private void BtnChangeName_Click(object sender, EventArgs e)
		{
			try
			{
				CheckExitConditions();
				ExecuteSelectedOption();
				SetComponentsToEmptyValue();
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "Błąd wprowadzonych danych!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (InvalidOperationException ex)
			{
				MessageBox.Show(ex.Message, "Błąd wykonywania programu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Katastrofalny błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				RefreshChListFiles();
			}
		}

		private void ExecuteSelectedOption()
		{
			string[] checkedItems = new string[ChListFiles.CheckedItems.Count];
			ChListFiles.CheckedItems.CopyTo(checkedItems, 0);

			if (RbNewName.Checked)
				fileNameChange.SetNewName(checkedItems, TxtNewName.Text);
			else if (RbPrefix.Checked)
				fileNameChange.SetPrefix(checkedItems, TxtPrefix.Text);
			else if (RbSuffix.Checked)
				fileNameChange.SetSuffix(checkedItems, TxtSuffix.Text);
			else if (RbRepleaceAll.Checked)
				fileNameChange.SetRepleaceAll(checkedItems, TxtRepleaceAllOld.Text, TxtRepleaceAllNew.Text);
			else if (RbReplaceSelected.Checked)
				fileNameChange.SetReplaceSelected(checkedItems, TxtReplaceSelectedOld.Text, TxtReplaceSelectedNew.Text, (int)NumReplaceSelectedIndex.Value);
			else if (RbAddNumbering.Checked)
				fileNameChange.SetAddNumbering(checkedItems, RbAddNumberingStart.Checked, (int)NumAddNumberingStart.Value, (int)NumAddNumberingInc.Value, TxtAddNumbering.Text);
			else if (RbToUpperCase.Checked)
				fileNameChange.SetToUpperCase(checkedItems);
			else if (RbToLowerCase.Checked)
				fileNameChange.SetToLowerCase(checkedItems);
			else if (RbFirstToUpperCase.Checked)
				fileNameChange.SetFirstToUpperCase(checkedItems);
			else if (RbFirstToLowerCase.Checked)
				fileNameChange.SetFirstToLowerCase(checkedItems);
			else if (RbDeleteNumbers.Checked)
				fileNameChange.SetDeleteNumbers(checkedItems);
			else if (RbDeleteLetters.Checked)
				fileNameChange.SetDeleteLetters(checkedItems);
			else if (RbDeleteWhiteSpace.Checked)
				fileNameChange.SetDeleteWhiteSpace(checkedItems);
			else if (RbDeleteChars.Checked)
				fileNameChange.SetDeleteChars(checkedItems);
			else if (RbDeleteChar.Checked)
				fileNameChange.SetDeleteChar(checkedItems, (int)NumDeleteChar.Value - 1);
			else if (RbDeleteFewChars.Checked)
				fileNameChange.SetDeleteFewChars(checkedItems, (int)NumDeleteFewCharsStart.Value - 1, (int)NumDeleteFewCharsNumber.Value);
			else if (RbDeleteLastChar.Checked)
				fileNameChange.SetDeleteLastChar(checkedItems);
			else if (RbDeleteLastChars.Checked)
				fileNameChange.SetDeleteLastChars(checkedItems, (int)NumDeleteLastChars.Value);
		}

		//private void FillChListFiles(string selectedPath)
		//{
		//	fileNameChange.FillFileNames(selectedPath);
		//	ChListFiles.Items.Clear();
		//	ChListFiles.Items.AddRange(fileNameChange.GetShortFileNames());
		//}

		private void FillChListFiles(string[] selectedFiles)
		{
			fileNameChange.FillFileNames(selectedFiles);
			RefreshChListFiles();
		}

		private void RefreshChListFiles()
		{
			ChListFiles.Items.Clear();
			ChListFiles.Items.AddRange(fileNameChange.GetShortFileNames());
			ChSelectAll.Checked = false;
			lblDragDrop.Visible = false;
			BtnChangeName.Enabled = BtnClear.Enabled = BtnRefresh.Enabled = ChListFiles.Items.Count > 0 ? true : false;
		}

		private void BtnClear_Click(object sender, EventArgs e)
		{
			ChListFiles.Items.Clear();
			SetComponentsToEmptyValue();
		}

		private void BtnRefresh_Click(object sender, EventArgs e)
		{
			RefreshChListFiles();
		}

		private void SetComponentsToEmptyValue()
		{
			multiselectStartIndex = 0;
			isMultiselect = false;

			if (ChListFiles.Items.Count == 0)
			{
				BtnChangeName.Enabled = false;
				BtnClear.Enabled = false;
				lblDragDrop.Visible = true;
			}

			NumReplaceSelectedIndex.Value = NumDeleteChar.Value = NumDeleteFewCharsStart.Value = NumDeleteFewCharsNumber.Value = NumAddNumberingStart.Value = NumAddNumberingInc.Value = NumDeleteLastChars.Value = 0;

			TxtNewName.Text = TxtPrefix.Text = TxtSuffix.Text = TxtRepleaceAllOld.Text = TxtRepleaceAllNew.Text = TxtReplaceSelectedOld.Text = TxtReplaceSelectedNew.Text = TxtAddNumbering.Text = "";

			ChSelectAll.Checked = RbNewName.Checked = RbPrefix.Checked = RbSuffix.Checked = RbRepleaceAll.Checked = RbReplaceSelected.Checked = RbToUpperCase.Checked = RbToLowerCase.Checked = RbFirstToUpperCase.Checked = RbFirstToLowerCase.Checked = RbDeleteNumbers.Checked
				= RbDeleteLetters.Checked = RbDeleteWhiteSpace.Checked = RbDeleteChars.Checked = RbDeleteChar.Checked = RbDeleteFewChars.Checked = RbAddNumbering.Checked = RbAddNumberingStart.Checked
				= RbAddNumberingEnd.Checked = RbDeleteLastChar.Checked = RbDeleteLastChars.Checked = false;
		}

		private void CheckExitConditions()
		{
			if (ChListFiles.CheckedItems.Count == 0)
				throw new ArgumentException("Wybierz plik do zmiany!");

			if (!RbNewName.Checked && !RbPrefix.Checked && !RbSuffix.Checked && !RbRepleaceAll.Checked && !RbReplaceSelected.Checked && !RbToUpperCase.Checked && !RbToLowerCase.Checked && !RbFirstToUpperCase.Checked && !RbFirstToLowerCase.Checked
				&& !RbDeleteNumbers.Checked && !RbDeleteLetters.Checked && !RbDeleteWhiteSpace.Checked && !RbDeleteChars.Checked && !RbDeleteChar.Checked && !RbDeleteFewChars.Checked
				&& !RbAddNumbering.Checked && !RbDeleteLastChar.Checked && !RbDeleteLastChars.Checked)
				throw new ArgumentException("Wybierz jakąś operację związaną z nazwą pliku!");

			if (RbNewName.Checked && TxtNewName.Text == "")
				throw new ArgumentException("Wpisz nową nazwę pliku!");

			if (RbPrefix.Checked && TxtPrefix.Text == "")
				throw new ArgumentException("Wpisz brakujący przedrostek!");

			if (RbSuffix.Checked && TxtSuffix.Text == "")
				throw new ArgumentException("Wpisz brakujący przyrostek!");

			if (RbRepleaceAll.Checked && TxtRepleaceAllOld.Text == "")
				throw new ArgumentException("Uzupełnij zamieniane znaki!");

			if (RbReplaceSelected.Checked && TxtReplaceSelectedOld.Text == "")
				throw new ArgumentException("Uzupełnij zamieniane znaki!");

			if (RbReplaceSelected.Checked && NumReplaceSelectedIndex.Value < 1)
				throw new ArgumentException("Podaj numer wystąpienia znaku, który chcesz zastąpić");

			if (RbReplaceSelected.Checked && TxtReplaceSelectedOld.Text.Length > 1)
				throw new ArgumentException("Wprowadź tylko 1 znak do zastąpienia!");

			if (RbDeleteChar.Checked && NumDeleteChar.Value < 1)
				throw new ArgumentException("Wprowadź pozycję znaku do usunięcia!");

			if (RbDeleteFewChars.Checked && (NumDeleteFewCharsStart.Value < 1 || NumDeleteFewCharsNumber.Value < 1))
				throw new ArgumentException("Wprowadź pozycję startową i ilość znaków do usunięcia!");

			if (RbAddNumbering.Checked && NumAddNumberingInc.Value < 1)
				throw new ArgumentException("Wprowadź wartość kroku zwiększającego numerację!");

			if (RbAddNumbering.Checked && !(RbAddNumberingStart.Checked || RbAddNumberingEnd.Checked))
				throw new ArgumentException("Określ czy numeracja ma być na początku lub na końcu nazwy!");

			if (RbDeleteLastChars.Checked && NumDeleteLastChars.Value < 0)
				throw new ArgumentException("Podaj ilość znaków do usunięcia!");
		}

		private void ChListFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			int multiselectIndex = ChListFiles.SelectedIndex;

			if (!isMultiselect)
			{
				multiselectStartIndex = multiselectIndex;
				if (multiselectIndex >= 0)
					isChecked = ChListFiles.GetItemChecked(multiselectIndex);
			}
			else
				_ = multiselectStartIndex < multiselectIndex ? SelectItems(multiselectStartIndex, multiselectIndex) : SelectItems(multiselectIndex, multiselectStartIndex);

			bool SelectItems(int start, int stop)
			{
				for (int i = start; i <= stop; i++)
					ChListFiles.SetItemChecked(i, isChecked);
				return true;
			}

			if (ChListFiles.Items.Count == ChListFiles.CheckedItems.Count)
			{
				ChSelectAll.CheckedChanged -= ChSelectAll_CheckedChanged;
				ChSelectAll.Checked = true;
				ChSelectAll.CheckedChanged += ChSelectAll_CheckedChanged;
			}

			if (ChListFiles.CheckedItems.Count == 0)
			{
				ChSelectAll.CheckedChanged -= ChSelectAll_CheckedChanged;
				ChSelectAll.Checked = false;
				ChSelectAll.CheckedChanged += ChSelectAll_CheckedChanged;
			}
		}

		private void MainWindow_KeyUp(object sender, KeyEventArgs e)
		{
			isMultiselect = e.KeyCode != Keys.ShiftKey;
		}

		private void MainWindow_KeyDown(object sender, KeyEventArgs e)
		{
			isMultiselect = e.Shift;
		}

		private void TxtNewName_TextChanged(object sender, EventArgs e)
		{
			RbNewName.Checked = true;
		}

		private void TxtPrefix_TextChanged(object sender, EventArgs e)
		{
			RbPrefix.Checked = true;
		}

		private void TxtSuffix_TextChanged(object sender, EventArgs e)
		{
			RbSuffix.Checked = true;
		}

		private void TxtRepleaceAllTextChanged(object sender, EventArgs e)
		{
			RbRepleaceAll.Checked = true;
		}

		private void NumReplaceSelectedValueChanged(object sender, EventArgs e)
		{
			RbReplaceSelected.Checked = true;
		}

		private void NumDeleteChar_ValueChanged(object sender, EventArgs e)
		{
			RbDeleteChar.Checked = true;
		}

		private void NumDeleteFewCharsValueChanged(object sender, EventArgs e)
		{
			RbDeleteFewChars.Checked = true;
		}

		private void NumAddNumberingValueChanged(object sender, EventArgs e)
		{
			RbAddNumbering.Checked = true;
		}

		private void RbAddNumberingStartEndCheckedChanged(object sender, EventArgs e)
		{
			RbAddNumbering.Checked = RbAddNumberingStart.Checked || RbAddNumberingEnd.Checked;
		}

		private void RbAddNumbering_CheckedChanged(object sender, EventArgs e)
		{
			if (!RbAddNumbering.Checked)
				RbAddNumberingStart.Checked = RbAddNumberingEnd.Checked = false;
		}

		private void NumDeleteLastChars_ValueChanged(object sender, EventArgs e)
		{
			RbDeleteLastChars.Checked = true;
		}

		private void ChListFiles_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;
			else
				e.Effect = DragDropEffects.None;
		}

		private void ChListFiles_DragDrop(object sender, DragEventArgs e)
		{
			List<string> filepaths = new List<string>();
			foreach (var s in (string[])e.Data.GetData(DataFormats.FileDrop, false))
			{
				if (Directory.Exists(s))
				{
					//Add files from folder
					filepaths.AddRange(Directory.GetFiles(s));
				}
				else
				{
					//Add filepath
					filepaths.Add(s);
				}
			}
			FillChListFiles(filepaths.ToArray());
			//lblDragDrop.Visible = false;
			//if (ChListFiles.Items.Count > 0)
			//{
			//	BtnChangeName.Enabled = true;
			//	BtnClear.Enabled = true;
			//}
		}
	}
}