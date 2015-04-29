using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;


public class PersianMaker
{
   	public string mainString="";
	
	// Persian character map
    private List<PersianCharacter> CharacterMap;

    public PersianMaker()
    {
        CharacterMap = new List<PersianCharacter>();

#region ABaKolah آ
        CharacterMap.Add(new PersianCharacter("ABaKolah", true, 
                         0x622, 0x622, 0xfe82, 0xfe81, 0xfe82, 0xfe81));
# endregion

#region Alef ا
        CharacterMap.Add(new PersianCharacter("Alef", true, 0x627, 
                         0x627, 0xfe8e, 0xfe8d, 0xfe8e, 0xfe8d));
# endregion

#region AlefWithHamzeAbove أ
        CharacterMap.Add(new PersianCharacter("AlefWithHamzeAbove", 
                         true, 0x623, 0x623, 0xfe84, 0xfe83, 0xfe84, 0xfe83));
# endregion

#region AlefWithHamzeBelow إ
        CharacterMap.Add(new PersianCharacter("AlefWithHamzeBelow", 
                         true, 0x625, 0x625, 0xfe88, 0xfe87, 0xfe88, 0xfe87));
# endregion

#region Hamze ء
        CharacterMap.Add(new PersianCharacter("Hamze", true, 
                         0x621, 0x621, 0xfe80, 0xfe80, 0xfe80, 0xfe7f));
# endregion

#region Be ب
        CharacterMap.Add(new PersianCharacter("Be", false, 
                         0x628, 0x628, 0xfe90, 0xfe91, 0xfe92, 0xfe8f));
# endregion

#region Pe پ
        CharacterMap.Add(new PersianCharacter("Pe", false, 
                         0x67e, 0x67e, 0xfb57, 0xfb58, 0xfb59, 0xfb56));
# endregion

#region Te ت
        CharacterMap.Add(new PersianCharacter("Te", false, 
                         0x62a, 0x62a, 0xfe96, 0xfe97, 0xfe98, 0xfe95));
# endregion

#region Theh ث
        CharacterMap.Add(new PersianCharacter("Theh", false, 
                         0x62b, 0x62b, 0xfe9a, 0xfe9b, 0xfe9c, 0xfe99));
# endregion

#region Jeem ج
        CharacterMap.Add(new PersianCharacter("Jeem", false, 
                         0x62c, 0x62c, 0xfe9e, 0xfe9f, 0xfea0, 0xfe9d));
# endregion

#region Che چ
        CharacterMap.Add(new PersianCharacter("Che", false, 
                         0x686, 0x686, 0xfb7b, 0xfb7c, 0xfb7d, 0xfb7a));
# endregion

#region Hah ح
        CharacterMap.Add(new PersianCharacter("Hah", false, 
                         0x62d, 0x62d, 0xfea2, 0xfea3, 0xfea4, 0xfea1));
# endregion

#region Kheh خ
        CharacterMap.Add(new PersianCharacter("Kheh", false, 
                         0x62e, 0x62e, 0xfea6, 0xfea7, 0xfea8, 0xfea5));
# endregion

#region Dal د
        CharacterMap.Add(new PersianCharacter("Dal", true, 
                         0x62f, 0x62f, 0xfeaa, 0xfea9, 0xfeaa, 0xfea9));
# endregion

#region Zal ذ
        CharacterMap.Add(new PersianCharacter("Zal", true, 
                         0x630, 0x630, 0xfeac, 0xfeab, 0xfeac, 0xfeab));
# endregion

#region Re ر
        CharacterMap.Add(new PersianCharacter("Re", true, 0x631, 
                         0x631, 0xfeae, 0xfead, 0xfeae, 0xfead));
# endregion

#region Ze ز
        CharacterMap.Add(new PersianCharacter("Ze", true, 
                         0x632, 0x632, 0xfeb0, 0xfeaf, 0xfeb0, 0xfeaf));
# endregion

#region Je ژ
        CharacterMap.Add(new PersianCharacter("Je", true, 
                         0x698, 0x698, 0xfb8b, 0xfb8a, 0xfb8b, 0xfb8a));
# endregion

#region Seen س
        CharacterMap.Add(new PersianCharacter("Seen", false, 
                         0x633, 0x633, 0xfeb2, 0xfeb3, 0xfeb4, 0xfeb1));
# endregion

#region Sheen ش
        CharacterMap.Add(new PersianCharacter("Sheen", false, 
                         0x634, 0x634, 0xfeb6, 0xfeb7, 0xfeb8, 0xfeb5));
# endregion

#region Sad ص
        CharacterMap.Add(new PersianCharacter("Sad", false, 
                         0x635, 0x635, 0xfeba, 0xfebb, 0xfebc, 0xfeb9));
# endregion

#region Zad ض
        CharacterMap.Add(new PersianCharacter("Zad", false, 
                         0x636, 0x636, 0xfebe, 0xfebf, 0xfec0, 0xfebd));
# endregion

#region Ta ط
        CharacterMap.Add(new PersianCharacter("Ta", false, 
                         0x637, 0x637, 0xfec2, 0xfec3, 0xfec4, 0xfec1));
# endregion

#region Za ظ
        CharacterMap.Add(new PersianCharacter("Za", false, 
                         0x638, 0x638, 0xfec6, 0xfec7, 0xfec8, 0xfec5));
# endregion

#region Ein ع
        CharacterMap.Add(new PersianCharacter("Ein", false, 
                         0x639, 0xfeca, 0xfeca, 0xfecb, 0xfecc, 0xfec9));
# endregion

#region Ghein غ
        CharacterMap.Add(new PersianCharacter("Ghein", false, 
                         0x63a, 0x63a, 0xfece, 0xfecf, 0xfed0, 0xfecd));
# endregion

#region Fe ف
        CharacterMap.Add(new PersianCharacter("Fe", false, 
                         0x641, 0x641, 0xfed2, 0xfed3, 0xfed4, 0xfed1));
# endregion

#region Ghaf ق
        CharacterMap.Add(new PersianCharacter("Ghaf", false, 
                         0x642, 0x642, 0xfed6, 0xfed7, 0xfed8, 0xfed5));
# endregion

#region kaf ک
        CharacterMap.Add(new PersianCharacter("kaf", false, 
                         0x6a9, 0x6a9, 0xfeda, 0xfedb, 0xfedc, 0xfed9));
# endregion

#region Gaf گ
        CharacterMap.Add(new PersianCharacter("Gaf", false, 
                         0x6af, 0x6af, 0xfb93, 0xfb94, 0xfb95, 0xfb92));
# endregion

#region Lam ل
        CharacterMap.Add(new PersianCharacter("Lam", false, 
                         0x644, 0x644, 0xfede, 0xfedf, 0xfee0, 0xfedd));
# endregion

#region Meem م
        CharacterMap.Add(new PersianCharacter("Meem", false, 
                         0x645, 0x645, 0xfee2, 0xfee3, 0xfee4, 0xfee1));
# endregion

#region Noon ن
        CharacterMap.Add(new PersianCharacter("Noon", false, 
                         0x646, 0x646, 0xfee6, 0xfee7, 0xfee8, 0xfee5));
# endregion

#region Vav و
        CharacterMap.Add(new PersianCharacter("Vav", true, 0x648, 
                         0x648, 0xfeee, 0xfeed, 0xfeee, 0xfeed));
# endregion

#region VavBaHamze ؤ
        CharacterMap.Add(new PersianCharacter("VavBaHamze", true, 
                         0x624, 0x624, 0xfe86, 0xfe85, 0xfe86, 0xfe85));
# endregion

#region Heh ه
        CharacterMap.Add(new PersianCharacter("Heh", false, 
                         0x647, 0x647, 0xfeea, 0xfeeb, 0xfeec, 0xfee9));
# endregion

#region TehMarbuta ة
        CharacterMap.Add(new PersianCharacter("TehMarbuta", 
                         true, 0x629, 0x629, 0xfe94, 0xfe93, 0xfe93, 0xfe93));
# endregion

#region Ye ی
        CharacterMap.Add(new PersianCharacter("Ye", false, 
                         0x6cc, 0x6cc, 0xfef0, 0xfef3, 0xfef4, 0xfeef));
# endregion

#region ArabicYe ي
        CharacterMap.Add(new PersianCharacter("ArabicYe", false, 
                         0x64a, 0x64a, 0xfef2, 0xfef3, 0xfef4, 0xfef1));
# endregion

#region YeBaHamze ئ
        CharacterMap.Add(new PersianCharacter("YeBaHamze", false, 
                         0x626, 0x626, 0xfe8a, 0xfe8b, 0xfe8c, 0xfe89));
# endregion 

    }

    /// <summary>
    /// Check whether the character belongs to the Persian character list or not.
    /// </summary>
    /// <param name="ch"></param>
    /// <returns>true if the character belongs to the
    /// Persian character list; otherwise, false.</returns>
    private bool IsPersianCharacter(char ch)
    {
        bool result = false;
        var query = from cm in CharacterMap
        where cm.StartChar == ch ||
        cm.MiddleRightSideBoundedChar == ch ||
        cm.MiddleLeftSideBoundedChar == ch ||
        cm.MiddleTwoSideBoundedChar == ch ||
        cm.EndingBoundedChar == ch ||
        cm.EndingChar == ch
        select cm.CharacterName;

        if (query.Count() > 0)
        {
            result = true;
        }
        return result;
    }

    /// <summary>
    /// Check whether the character is from NoLastAppend group or not.
    /// </summary>
    /// <param name="ch"></param>
    /// <returns>true if the character is from NoLastAppend group;
    /// otherwise, false.</returns>
    private bool IsNoLastAppendCharacter(char ch)
    {
        bool result = false;
        var query = from cm in CharacterMap
        where (cm.StartChar == ch ||
        cm.MiddleRightSideBoundedChar == ch ||
        cm.MiddleLeftSideBoundedChar == ch ||
        cm.MiddleTwoSideBoundedChar == ch ||
        cm.EndingBoundedChar == ch ||
        cm.EndingChar == ch) & cm.NoLastAppend == true
        select cm.NoLastAppend;
        if (query.Count() > 0)
        {
            result = true;
        }
        return result;
    }

    /// <summary>
    /// Generates a correct Persian text to be presented
    /// in the silverlight context.
    /// </summary>
    /// <param name="text"></param>
    /// <returns>Persian correct format of the text</returns>
    private string ToPersianString(string text)
    {
        int i = 0;
        string str2 = "";
        while (i < text.Length)
        {
            ECharPossition possition= ECharPossition.StartingChar;
            // get current letter
            if (IsPersianCharacter(Convert.ToChar(text.Substring(i, 1))))
            {
                if (i == 0)// This is the first chraracter of the string
                {
                    possition = ECharPossition.StartingChar;
                }
                else if (i == (text.Length - 1))
                // This is the last character of the string
                {
                    // get letter before
                    if (IsPersianCharacter(Convert.ToChar(text.Substring(i - 1, 1))))
                    {
                        if (IsNoLastAppendCharacter(
                             Convert.ToChar(text.Substring(i - 1, 1))))
                        {
                            possition = ECharPossition.EndingChar;
                        }
                        else
                        {
                            possition = ECharPossition.EndingBoundedChar;
                        }
                    }
                    else
                    {
                        possition = ECharPossition.EndingBoundedChar;
                    }
                }
                else // the current character is neither first nor last
                {
                    // get letter before
                    if (IsPersianCharacter(
                           Convert.ToChar(text.Substring(i - 1, 1))))
                    {
                        if (IsNoLastAppendCharacter(
                              Convert.ToChar(text.Substring(i - 1, 1))))
                        {
                            // get current letter
                            if (IsPersianCharacter(
                                 Convert.ToChar(text.Substring(i, 1))))
                            {
                                if (!IsNoLastAppendCharacter(
                                      Convert.ToChar(text.Substring(i, 1))))
                                {
                                    possition = 
                                      ECharPossition.MiddleLeftSideBoundedChar;
                                }
                                else
                                {
                                    possition = ECharPossition.StartingChar;
                                }
                            }
                            else
                            {
                                possition = ECharPossition.StartingChar;
                            }
                        }
                        else
                        {
                            possition = ECharPossition.MiddleTwoSidesBoundedChar;
                        }
                    }
                    else
                    {
                        possition = ECharPossition.StartingChar;
                    }
                }

                // get current letter
                char currentChar = Convert.ToChar(text.Substring(i, 1));
                var query = from cm in CharacterMap
                where cm.StartChar == currentChar ||
                cm.MiddleRightSideBoundedChar == currentChar ||
                cm.MiddleLeftSideBoundedChar == currentChar ||
                cm.MiddleTwoSideBoundedChar == currentChar ||
                cm.EndingBoundedChar == currentChar ||
                cm.EndingChar == currentChar
                select cm;
    
                //Retreive the character set of the current letter
                PersianCharacter pch = query.First();
                if (pch != null)
                {
                    switch (possition)
                    {
                        case ECharPossition.StartingChar:
                            str2 = str2 + 
                              Convert.ToChar(pch.MiddleTwoSideBoundedChar).ToString();
                            break;
                        case ECharPossition.MiddleRightSideBoundedChar: ;
                            str2 = str2 + 
                              Convert.ToChar(pch.EndingBoundedChar).ToString();
                            break;
                        case ECharPossition.MiddleLeftSideBoundedChar:
                            str2 = str2 + 
                              Convert.ToChar(pch.MiddleTwoSideBoundedChar).ToString();
                            break;
                        case ECharPossition.MiddleTwoSidesBoundedChar:
                            str2 = str2 + 
                              Convert.ToChar(pch.EndingBoundedChar).ToString();
                            break;
                        case ECharPossition.EndingBoundedChar:
                            str2 = str2 + 
                              Convert.ToChar(pch.MiddleLeftSideBoundedChar).ToString();
                            break;
                        case ECharPossition.EndingChar:
                            str2 = str2 + Convert.ToChar(pch.EndingChar).ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                // The character does not belong to the CharMap
                str2 = str2 + text.Substring(i, 1);
            }
            i++;
        }
        return this.ReverseString(str2);
    }

    public string ToPersian(string text)
    {
        string str = "";
        string[] strArray0 = text.Split('\n');
        for (int j = strArray0.Length - 1; j >= 0; j--)
        {
            string[] strArray1 = strArray0[j].Split(new char[] { ' ' });
            int upperBound = strArray1.GetUpperBound(0);
            for (int i = 0; i <= upperBound; i++)
            {
                str = this.ToPersianString(strArray1[i]) + " " + str;
            }
            str = "\n" + str;
        }
        str.Trim();
        return str;
    }
	
	public string ToPersian1(string text)
    {
        string str = "";
		
		List<string> listOfWords;
		//splite string to word with space character
		listOfWords=SplitTextByWord(text," ");
		
		//to persian
		foreach(string sstr in listOfWords)
		{
			str=this.ToPersianString(sstr)+' '+str;
		}
		mainString=str;
        return str;
    }
	
	public static List<string> SplitTextByWord(string text, string splitTerm)
	{
    List<string> splitItems = new List<string>();
    if (string.IsNullOrEmpty(text)) return splitItems;
    if (string.IsNullOrEmpty(splitTerm))
    {
        splitItems.Add(text);
        return splitItems;
    }
    int nextPos = 0;
    int curPos = 0;
    while (nextPos > -1)
    {
        nextPos = text.IndexOf(splitTerm, curPos);
        if (nextPos != -1)
        {
            splitItems.Add(text.Substring(curPos, nextPos - curPos));
            curPos = nextPos + splitTerm.Length;
        }
    }
    splitItems.Add(text.Substring(curPos, text.Length - curPos));
 
    return splitItems;
}

	
	
    /// <summary>
    /// Reverse the specified string to become right to left.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private string ReverseString(string str)
    {
        string str2 = "";
        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (IsPersianCharacter(Convert.ToChar(str.Substring(i, 1))))
            {
                str2 = str2 + str.Substring(i, 1);
            }
            else
            {
                str2 = str.Substring(i, 1) + str2;
            }
        }
        return str2;
    }

    private enum ECharPossition
    {
        StartingChar,
        MiddleRightSideBoundedChar,
        MiddleLeftSideBoundedChar,
        MiddleTwoSidesBoundedChar,
        EndingBoundedChar,
        EndingChar
    }
}