using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] _lines;
    [SerializeField] private GameObject _startline;
    [SerializeField] private int _startSumSetLines;

    private GameObject[] _firstReserveLines;
    private GameObject[] _secondReserveLines;
    private bool _oneCellInLine = true;
    private int _numberPrevLine = 0;
    private int _randomValue;
    private Vector3 _presentPos;

    private void Awake()
    {
        _startline = Instantiate(_startline);
        _firstReserveLines = _lines;
        _secondReserveLines = _lines;
        InstArray(_lines);
        InstArray(_firstReserveLines);
        InstArray(_secondReserveLines);
    }

    void Start()
    {
        RespawnLines.GenerateLines += LinesGenerator;
        _lines[_numberPrevLine].SetActive(true);
        _lines[_numberPrevLine].transform.position = new Vector3(_startline.transform.position.x, _startline.transform.position.y + 1, _startline.transform.position.z);
        _presentPos = _lines[_numberPrevLine].transform.position;
        for (int i = 0; i < _startSumSetLines; i++)
        {
            LinesGenerator();
        }
    }


    private void LinesGenerator()
    {
        if (_oneCellInLine)
        {
            if (_numberPrevLine == 0)
            {
                _randomValue = Random.Range(1, 3);
                Debug.Log("Первая генерация веро " + _randomValue);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(4);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(10);
                }
                else if (_randomValue == 3)
                {
                    ChangeLinePosition(_numberPrevLine);
                }
            }
            else if (_numberPrevLine == 1)
            {
                _randomValue = Random.Range(1, 3);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(4);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(5);
                }
                else if (_randomValue == 3)
                {
                    ChangeLinePosition(_numberPrevLine);
                }
            }
            else if (_numberPrevLine == 2)
            {
                _randomValue = Random.Range(1, 3);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(5);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(6);
                }
                else if (_randomValue == 3)
                {
                    ChangeLinePosition(_numberPrevLine);
                }
            }
            else if (_numberPrevLine == 2)
            {
                _randomValue = Random.Range(1, 2);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(6);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(_numberPrevLine);
                }
            }
            else if (_numberPrevLine == 7)
            {
                _randomValue = Random.Range(1, 3);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(10);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(11);
                }
                else if (_randomValue == 3)
                {
                    ChangeLinePosition(_numberPrevLine);
                }
            }
            else if (_numberPrevLine == 7)
            {
                _randomValue = Random.Range(1, 3);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(11);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(12);
                }
                else if (_randomValue == 3)
                {
                    ChangeLinePosition(_numberPrevLine);
                }
            }
            else if (_numberPrevLine == 9)
            {
                _randomValue = Random.Range(1, 2);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(12);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(_numberPrevLine);
                }
            }
        }
        else
        {
            if (_numberPrevLine == 4)
            {
                _randomValue = Random.Range(1, 2);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(0);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(1);
                }
            }
            else if (_numberPrevLine == 5)
            {
                _randomValue = Random.Range(1, 2);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(1);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(2);
                }
            }
            else if (_numberPrevLine == 6)
            {
                _randomValue = Random.Range(1, 2);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(2);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(3);
                }
            }
            else if (_numberPrevLine == 10)
            {
                _randomValue = Random.Range(1, 2);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(0);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(7);
                }
            }
            else if (_numberPrevLine == 11)
            {
                _randomValue = Random.Range(1, 2);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(7);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(8);
                }
            }
            else if (_numberPrevLine == 12)
            {
                _randomValue = Random.Range(1, 2);
                if (_randomValue == 1)
                {
                    ChangeLinePosition(8);
                }
                else if (_randomValue == 2)
                {
                    ChangeLinePosition(9);
                }
            }
        }
    }

    private void InstArray(GameObject[] array)
    {
        for (int i = 0; i < _lines.Length; i++)
        {
            array[i] = Instantiate(_lines[i]);
            array[i].SetActive(false);
        }
    }

    private void ChangeLinePosition(int numberLine)
    {
        Debug.Log("Я ОТРАБАТЫВАЮ" + numberLine);
        if (_lines[numberLine].active != true)
        {
            _lines[numberLine].SetActive(true);
            _lines[numberLine].transform.position = new Vector3(_presentPos.x, _presentPos.y + 1, _presentPos.z);

            if (numberLine != _numberPrevLine)
            {
                _oneCellInLine = false;
            }
            _numberPrevLine = numberLine;
        }
        else if (_firstReserveLines[numberLine].active != true)
        {
            _firstReserveLines[numberLine].SetActive(true);
            _firstReserveLines[numberLine].transform.position = new Vector3(_presentPos.x, _presentPos.y + 1, _presentPos.z);

            if (numberLine != _numberPrevLine)
            {
                _oneCellInLine = false;
            }
            _numberPrevLine = numberLine;
        }
        else if (_secondReserveLines[numberLine].active != true)
        {
            _secondReserveLines[numberLine].SetActive(true);
            _secondReserveLines[numberLine].transform.position = new Vector3(_presentPos.x, _presentPos.y + 1, _presentPos.z);

            if (numberLine != _numberPrevLine)
            {
                _oneCellInLine = false;
            }
            _numberPrevLine = numberLine;
        }

    }

    
    void Update()
    {
        
    }
}
