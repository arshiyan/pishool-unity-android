using System;
using System.Collections.Generic;
using System.Linq;



internal class PersianCharacter
{
    public PersianCharacter(string characterName, bool noLastAppend, int
             startChar, int middleRightSideBoundedChar, int 
         middleLeftSideBoundedChar, int middleTwoSideBoundedChar, int 
         endingBoundedChar, int endingChar)
    {
        CharacterName = characterName;
        NoLastAppend = noLastAppend;
        StartChar = startChar;
        MiddleRightSideBoundedChar = middleRightSideBoundedChar;
        MiddleLeftSideBoundedChar = middleLeftSideBoundedChar;
        MiddleTwoSideBoundedChar = middleTwoSideBoundedChar;
        EndingBoundedChar = endingBoundedChar;
        EndingChar = endingChar;
    }
    private string _CharacterName = "";
    public string CharacterName
    {
        get
        {
            return _CharacterName;
        }
        set
        {
            _CharacterName = value;
        }
    }
    private bool _NoLastAppend = false;
    public bool NoLastAppend
    {
        get
        {
            return _NoLastAppend;
        }
        set
        {
            _NoLastAppend = value;
        }
    }

    private int _StartChar = 0;
    public int StartChar
    {
        get
        {
            return _StartChar;
        }
        set
        {
            _StartChar = value;
        }
    }

    private int _MiddleRightSideBoundedChar = 0;
    public int MiddleRightSideBoundedChar
    {
        get
        {
            return _MiddleRightSideBoundedChar;
        }
        set
        {
            _MiddleRightSideBoundedChar = value;
        }
    }

    private int _MiddleLeftSideBoundedChar = 0;
    public int MiddleLeftSideBoundedChar
    {
        get
        {
            return _MiddleLeftSideBoundedChar;
        }
        set
        {
            _MiddleLeftSideBoundedChar = value;
        }
    }

    private int _MiddleTwoSideBoundedChar = 0;
    public int MiddleTwoSideBoundedChar
    {
        get
        {
            return _MiddleTwoSideBoundedChar;
        }
        set
        {
            _MiddleTwoSideBoundedChar = value;
        }
    }

    private int _EndingBoundedChar = 0;
    public int EndingBoundedChar
    {
        get
        {
            return _EndingBoundedChar;
        }
        set
        {
            _EndingBoundedChar = value;
        }
    }

    private int _EndingChar = 0;
    public int EndingChar
    {
        get
        {
            return _EndingChar;
        }
        set
        {
            _EndingChar = value;
        }
    }
}