using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCell : MonoBehaviour
{
    [SerializeField] private GameObject _rectangle;
    [SerializeField] private GameObject _emptyRectangle;
    [SerializeField] private int _sumLine;

    private Vector3 tempPosStart = new Vector3(0, 0, 0);

    private int[] _tempArrayCell;
    private int previusMainCell;
    private int _destroyed;
    private int _sumCell;

    private int mainCell;
    private int secondCell;
    private int counter;

    private int randomCell;
    private bool setPrevius = false;
    private bool setMain = false;

    private float posStartLine;

    void Start()
    {
        RespawnLines.GenerateLines += Counter;
        ConfigurateFirstLine();
    }

    private void ConfigurateFirstLine()
    {
        Vector3 posStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight / 2, 10));
        Vector3 posStartLine = posStart;
        posStartLine.y += 1;
        Vector3 posFinishLine = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 10));

        var width = (posFinishLine.x - posStartLine.x) / 0.5f;
        posStartLine.x += 0.25f;
        _sumCell = (int)width + 1;

        int[] nums = new int[_sumCell];
        int setValue = (int)_sumCell / 2;

        int value = 0;

        for (int i = 0; i < _sumCell; i++)
        {
            if (value == setValue)
            {
                nums[i] = 1;
            }
            else
            {
                nums[i] = 0;
            }
            value++;
        }
        SetLine(nums, posStartLine);
    }

    private void SetLine(int[] array, Vector3 posStart)
    {
        tempPosStart = posStart;
        foreach (var i in array)
        {
            if (i == 0)
            {
                Instantiate(_rectangle, posStart, Quaternion.identity);
                posStart.x += 0.5f;
            }
            else
            {
                Instantiate(_emptyRectangle, posStart, Quaternion.identity);
                posStart.x += 0.5f;
            }
        }
        
        _tempArrayCell = array;
        for (int x = 0; x < _sumLine; x++)
        {
            LineGenerator();
        }
    }

    private void Counter()
    {
        if (_destroyed < _sumCell)
        {
            _destroyed += 1;
        }
        else
        {
            _destroyed = 0;
            LineGenerator();
        }
    }

    private void LineGenerator()
    {
        mainCell = 100;
        secondCell = 100;
        counter = 0;
        foreach (var i in _tempArrayCell)
        {
            if (i == 1)
            {
                if (mainCell == 100)
                {
                    mainCell = counter;
                }
                else if (secondCell == 100)
                {
                    secondCell = counter;
                }
            }
            counter++;
        }

        int[] nums = new int[_tempArrayCell.Length];
        setPrevius = false;
        setMain = false;
        counter = 0;
        foreach (var i in nums)
        {
            if (counter != 0 && counter != 1 && counter != 1 && counter != nums.Length - 1 && counter != nums.Length - 3)
            {
                if (mainCell != 100 && secondCell == 100)
                {
                    if (counter == mainCell - 1)
                    {
                        randomCell = Random.Range(1, 10);
                        if (randomCell < 5)
                        {
                            nums[counter] = 1;
                            previusMainCell = counter;
                            setPrevius = true;
                        }
                    }
                    else if (counter == mainCell)
                    {
                        setMain = true;
                        nums[counter] = 1;
                    }
                    else if (setPrevius != true && setMain == true && counter == mainCell + 1)
                    {
                        randomCell = Random.Range(1, 10);
                        if (randomCell < 5)
                        {
                            previusMainCell = counter;
                            nums[counter] = 1;
                        }
                    }
                }
                else if (mainCell != 100 && secondCell != 100)
                {
                    if (counter == previusMainCell)
                    {
                        nums[counter] = 1;
                    }
                }
            }
            counter++;
        }

        posStartLine = tempPosStart.x;
        tempPosStart.y += 1;

        foreach (var i in nums)
        {
            if (i == 0)
            {
                Instantiate(_rectangle, tempPosStart, Quaternion.identity);
                tempPosStart.x += 0.5f;
            }
            else
            {
                Instantiate(_emptyRectangle, tempPosStart, Quaternion.identity);
                tempPosStart.x += 0.5f;
            }
        }
        tempPosStart.x = posStartLine;
        _tempArrayCell = nums;
    }
}