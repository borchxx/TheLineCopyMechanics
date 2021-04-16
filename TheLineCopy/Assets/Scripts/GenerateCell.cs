using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCell : MonoBehaviour
{
    [SerializeField] private GameObject _rectangle;
    [SerializeField] private GameObject _emptyRectangle;
    [SerializeField] private int _sumLine;

    private int[] tempArrayCell;
    private int previusMainCell;

    void Start()
    {
        ConfigurateFirstLine();
    }

    private void ConfigurateFirstLine()
    {
        Vector3 posStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight / 2, 10));
        Vector3 posStartLine = posStart;
        Vector3 posFinishLine = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 10));

        var width = (posFinishLine.x - posStartLine.x) / 0.5f;
        posStartLine.x += 0.25f;
        int sumCell = (int)width;

        int[] nums = new int[sumCell+1];
        int setValue = (int)sumCell / 2;

        int value = 0;

        for (int i = 0; i < sumCell; i++)
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
        Vector3 posStartLine = posStart;
        foreach (var i in array)
        {
            if (i == 0)
            {
                Instantiate(_rectangle, posStartLine, Quaternion.identity);
                posStartLine.x += 0.5f;
            }
            else
            {
                Instantiate(_emptyRectangle, posStartLine, Quaternion.identity);
                posStartLine.x += 0.5f;
            }
        }
        ConfigurateAllLine(array, posStart);
    }


    private void ConfigurateAllLine(int[] array, Vector3 posStart)
    {
        tempArrayCell = array;

        for (int x = 0; x < _sumLine; x++)
        {
            int mainCell = 100;
            int secondCell = 100;
            int counter = 0;
            foreach (var i in tempArrayCell)
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

            int[] nums = new int[array.Length];
            int randomCell;
            bool setPrevius = false;
            bool setMain = false;
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

            float posStartLine = posStart.x;
            posStart.y += 1;
            foreach (var i in nums)
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
            posStart.x = posStartLine;
            tempArrayCell = nums;
        } 
    }
}
