using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileNameChange
{
	enum ChangeNameType
	{
		NewName, Prefix, Suffix, ToUpperCase, ToLowerCase, FirstToUpperCase, FirstToLowerCase, DeleteNumbers, DeleteLetters, DeleteWhiteSpace, DeleteChars, DeleteLastChar, RepleaceAll, ReplaceSelected, AddNumbering, DeleteChar, DeleteFewChars,
		DeleteLastChars
	}

	class FileNameChange
	{
		private string[] filesInFolder;

		private string shortName;
		private string newName;
		private string ext;

		//public FileNameChange(string selectedPath)
		//public FileNameChange()
		//{
		//	//this.selectedPath = selectedPath;
		//}

		//public void FillFileNames(string selectedPath)
		//{
		//	filesInFolder = Directory.GetFiles(selectedPath);
		//}

		public void FillFileNames(string[] selectedFiles)
		{
			filesInFolder = selectedFiles;
		}

		public string[] GetShortFileNames()
		{
			if (filesInFolder.Length > 0)
				return filesInFolder.Select(x => x.Substring(x.LastIndexOf(@"\") + 1)).ToArray();
			else
				throw new InvalidOperationException("Nie wybrano żadnych plików!");
		}

		public void SetNewName(string[] checkedCollection, string newNameText)
		{
			//string[] extList = checkedCollection.Select(c => c.Substring(c.LastIndexOf('.'))).Distinct().ToArray();
			string[] extList = checkedCollection.Select(Path.GetExtension).Distinct().ToArray();
			for (int i = 0; i < extList.Length; i++)
			{
				int number = 1;
				Array.ForEach(checkedCollection, c =>
				{
					PrepareNewName(c);
					if (extList[i] == ext)
					{
						newName = checkedCollection.Length == 1 ? newNameText : $"{newNameText} ({number++})";
						ChangeFileName(c);
					}
				});
			}
		}

		public void SetPrefix(string[] checkedCollection, string prefix)
		{
			ChangeName(ChangeNameType.Prefix, checkedCollection, prefix);
		}

		public void SetSuffix(string[] checkedCollection, string suffix)
		{
			ChangeName(ChangeNameType.Suffix, checkedCollection, suffix);
		}

		public void SetRepleaceAll(string[] checkedCollection, string textToReplace, string replacingText)
		{
			ChangeName(ChangeNameType.RepleaceAll, checkedCollection, textToReplace, replacingText);
		}

		public void SetReplaceSelected(string[] checkedCollection, string charToReplace, string replacingChar, int occurrenceNumber)
		{
			ChangeName(ChangeNameType.ReplaceSelected, checkedCollection, charToReplace, replacingChar, occurrenceNumber);
		}

		public void SetAddNumbering(string[] checkedCollection, bool isStart, int startNumber, int increment, string separator)
		{
			ChangeName(ChangeNameType.AddNumbering, checkedCollection, text1: separator, number1: startNumber, number2: increment, isCondition: isStart);
		}

		public void SetToUpperCase(string[] checkedCollection)
		{
			ChangeName(ChangeNameType.ToUpperCase, checkedCollection);
		}

		public void SetToLowerCase(string[] checkedCollection)
		{
			ChangeName(ChangeNameType.ToLowerCase, checkedCollection);
		}

		public void SetFirstToUpperCase(string[] checkedCollection)
		{
			ChangeName(ChangeNameType.FirstToUpperCase, checkedCollection);
		}

		public void SetFirstToLowerCase(string[] checkedCollection)
		{
			ChangeName(ChangeNameType.FirstToLowerCase, checkedCollection);
		}

		public void SetDeleteNumbers(string[] checkedCollection)
		{
			ChangeName(ChangeNameType.DeleteNumbers, checkedCollection);
		}

		public void SetDeleteLetters(string[] checkedCollection)
		{
			ChangeName(ChangeNameType.DeleteLetters, checkedCollection);
		}

		public void SetDeleteWhiteSpace(string[] checkedCollection)
		{
			ChangeName(ChangeNameType.DeleteWhiteSpace, checkedCollection);
		}

		public void SetDeleteChars(string[] checkedCollection)
		{
			ChangeName(ChangeNameType.DeleteChars, checkedCollection);
		}

		public void SetDeleteChar(string[] checkedCollection, int charPosition)
		{
			ChangeName(ChangeNameType.DeleteChar, checkedCollection, number1: charPosition);
		}

		public void SetDeleteFewChars(string[] checkedCollection, int startPosiotion, int howManyChars)
		{
			ChangeName(ChangeNameType.DeleteFewChars, checkedCollection, number1: startPosiotion, number2: howManyChars);
		}

		public void SetDeleteLastChar(string[] checkedCollection)
		{
			ChangeName(ChangeNameType.DeleteLastChar, checkedCollection);
		}

		public void SetDeleteLastChars(string[] checkedCollection, int howManyChars)
		{
			ChangeName(ChangeNameType.DeleteLastChars, checkedCollection, number1: howManyChars);
		}

		//public void SetPrefix(string[] checkedCollection, string prefix)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		newName = prefix + newName;
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetSuffix(string[] checkedCollection, string suffix)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		newName += suffix;
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetRepleaceAll(string[] checkedCollection, string textToReplace, string replacingText)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		newName = newName.Replace(textToReplace, replacingText);
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetReplaceSelected(string[] checkedCollection, string charToReplace, string replacingChar, int occurrenceNumber)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		int count = 0;
		//		for (int j = 0; j < newName.Length; j++)
		//			if (newName[j] == charToReplace[0])
		//				if (++count == occurrenceNumber)
		//				{
		//					StringBuilder sb = new StringBuilder(newName);
		//					if (replacingChar.Length > 0)
		//						sb[j] = replacingChar[0];
		//					else
		//						sb.Remove(j, 1);
		//					newName = sb.ToString();
		//				}
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetAddNumbering(string[] checkedCollection, bool isStart, int startNumber, int increment, string separator)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		newName = isStart ? $"{startNumber}{separator}{newName}" : $"{newName}{separator}{startNumber}";
		//		startNumber += increment;
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetToUpperCase(string[] checkedCollection)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		newName = newName.ToUpper();
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetToLowerCase(string[] checkedCollection)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		newName = newName.ToLower();
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetDeleteNumbers(string[] checkedCollection)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		for (int j = newName.Length - 1; j >= 0; j--)
		//			if (char.IsDigit(newName[j]))
		//				newName = newName.Remove(j, 1);
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetDeleteLetters(string[] checkedCollection)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		for (int j = newName.Length - 1; j >= 0; j--)
		//			if (char.IsLetter(newName[j]))
		//				newName = newName.Remove(j, 1);
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetDeleteWhiteSpace(string[] checkedCollection)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		for (int j = newName.Length - 1; j >= 0; j--)
		//			if (char.IsWhiteSpace(newName[j]))
		//				newName = newName.Remove(j, 1);
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetDeleteChars(string[] checkedCollection)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		for (int j = newName.Length - 1; j >= 0; j--)
		//			if (!char.IsLetterOrDigit(newName[j]) && !char.IsWhiteSpace(newName[j]))
		//				newName = newName.Remove(j, 1);
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetDeleteChar(string[] checkedCollection, int charPosition)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		newName = newName.Remove(charPosition - 1, 1);
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetDeleteFewChars(string[] checkedCollection, int startPosiotion, int howManyChars)
		//{
		//	string message = "";

		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		if (newName.Length >= howManyChars)
		//			newName = newName.Remove(startPosiotion, howManyChars);
		//		else
		//			message += newName + ext + ", ";
		//		ChangeFileName(c);
		//	});

		//	if (message.Length > 0)
		//		throw new InvalidOperationException("Następujące pliki nie zostały zmienione: " + message.Remove(message.Length - 2, 2));
		//}

		//public void SetDeleteLastChar(string[] checkedCollection)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		newName = newName.Remove(newName.Length - 1);
		//		ChangeFileName(c);
		//	});
		//}

		//public void SetDeleteLastChars(string[] checkedCollection, int howManyChars)
		//{
		//	Array.ForEach(checkedCollection, c =>
		//	{
		//		PrepareNewName(c);
		//		newName = newName.Remove(newName.Length - howManyChars);
		//		ChangeFileName(c);
		//	});
		//}

		private void ChangeName(ChangeNameType type, string[] checkedCollection, string text1 = "", string text2 = "", int number1 = 0, int number2 = 0, bool isCondition = false)
		{
			string message = "";

			Array.ForEach(checkedCollection, c =>
			{
				PrepareNewName(c);

				switch (type)
				{
					case ChangeNameType.Prefix:
						newName = text1 + newName;
						break;
					case ChangeNameType.Suffix:
						newName += text1;
						break;
					case ChangeNameType.ToUpperCase:
						newName = newName.ToUpper();
						break;
					case ChangeNameType.ToLowerCase:
						newName = newName.ToLower();
						break;
					case ChangeNameType.FirstToUpperCase:
						newName = newName[0].ToString().ToUpper() + newName.Remove(0, 1);
						break;
					case ChangeNameType.FirstToLowerCase:
						newName = newName[0].ToString().ToLower() + newName.Remove(0, 1);
						break;
					case ChangeNameType.DeleteNumbers:
					case ChangeNameType.DeleteLetters:
					case ChangeNameType.DeleteWhiteSpace:
					case ChangeNameType.DeleteChars:
						for (int j = newName.Length - 1; j >= 0; j--)
							if (type == ChangeNameType.DeleteNumbers && char.IsDigit(newName[j])
							|| type == ChangeNameType.DeleteLetters && char.IsLetter(newName[j])
							|| type == ChangeNameType.DeleteWhiteSpace && char.IsWhiteSpace(newName[j])
							|| type == ChangeNameType.DeleteChars && (!char.IsLetterOrDigit(newName[j]) && !char.IsWhiteSpace(newName[j])))
								newName = newName.Remove(j, 1);
						break;
					case ChangeNameType.DeleteLastChar:
						newName = newName.Remove(newName.Length - 1);
						break;
					case ChangeNameType.RepleaceAll:
						newName = newName.Replace(text1, text2);
						break;
					case ChangeNameType.ReplaceSelected:
						int count = 0;
						for (int j = 0; j < newName.Length; j++)
							if (newName[j] == text1[0])
								if (++count == number1)
								{
									StringBuilder sb = new StringBuilder(newName);
									if (text2.Length > 0)
										sb[j] = text2[0];
									else
										sb.Remove(j, 1);
									newName = sb.ToString();
								}
						break;
					case ChangeNameType.AddNumbering:
						newName = isCondition ? $"{number1}{text1}{newName}" : $"{newName}{text1}{number1}";
						number1 += number2;
						break;
					case ChangeNameType.DeleteChar:
						newName = newName.Remove(number1 - 1, 1);
						break;
					case ChangeNameType.DeleteFewChars:
						if (newName.Length >= number2)
							newName = newName.Remove(number1, number2);
						else
							message += newName + ext + ", ";
						break;
					case ChangeNameType.DeleteLastChars:
						newName = newName.Remove(newName.Length - number1);
						break;
					default:
						break;
				}

				ChangeFileName(c);
			});

			if (message.Length > 0)
				throw new InvalidOperationException("Następujące pliki nie zostały zmienione: " + message.Remove(message.Length - 2, 2));
		}

		private void PrepareNewName(string oldName)
		{
			shortName = oldName;
			int extIndex = oldName.LastIndexOf('.');
			if (extIndex > -1)
			{
				// Path.GetExtension();
				ext = oldName.Substring(extIndex);
				newName = oldName.Remove(extIndex);
			}
			else
			{
				ext = string.Empty;
				newName = oldName;
			}
		}

		private void ChangeFileName(string oldShortName)
		{
			if (!filesInFolder.Contains(newName))
			{
				newName += ext;

				// Windows is no case-sensitive
				bool isTmpName = false;
				string tmpName = "PwfaCfJggwfDv0CndkCBXGAWEkqcdYifL_-NOgTn" + ext;  // Guid.NewGuid() - is better random name?

				string oldLongName = Array.Find(filesInFolder, c => c.Contains(oldShortName));
				string path = oldLongName.Substring(0, oldLongName.LastIndexOf(@"\") + 1);

				try
				{
					Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(oldLongName, tmpName);
					isTmpName = true;
					Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(path + tmpName, newName);

					filesInFolder[Array.IndexOf(filesInFolder, oldLongName)] = path + newName;
				}
				catch (Exception)
				{
					if (isTmpName)
						Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(path + tmpName, shortName);
					throw;
				}
			}
			else
				throw new InvalidOperationException($"{newName} - taki plik już istnieje w wybranym folderze!");
		}
	}
}
