using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManagerSC gameManagerSC;
    Sprite _firstSprite;
    Sprite _secondSprite;
    List<GameObject> _tableCells;
    int _score;
    void Start()
    {
        EventManager.LightControl(gameManagerSC.lightControl);
        EventManager.HardModeOnOff(gameManagerSC.hardMod);
        EventManager.DominoSprite(gameManagerSC.dominoSprite);
    }
    private void OnEnable()
    {
        EventManager.DominoSprites += DominoSprites;
        EventManager.TableCells += TableCells;
        EventManager.NewDomino += NewDomino;
        EventManager.EarnPoints += EarnPoints;
    }
    private void OnDisable()
    {
        EventManager.DominoSprites -= DominoSprites;
        EventManager.TableCells -= TableCells;
        EventManager.NewDomino -= NewDomino;
        EventManager.EarnPoints -= EarnPoints;
    }
    void EarnPoints(int point)
    {
        _score += point;
        gameManagerSC.score = _score;
    }
    void DominoSprites(Sprite firstSprite,Sprite secondSprite)
    {
        _firstSprite= firstSprite;
        _secondSprite= secondSprite;
    }
    void TableCells(List<GameObject> tableCell)
    {
        _tableCells= tableCell;
    }
    void NewDomino()
    {
        int settledDownInt = 0;
        for (int i = 0; i < _tableCells.Count; i++)
        {
            if (_tableCells[i].GetComponent<TableCellManager>().OnChildDominoBase == null)
            {
                _tableCells[i].GetComponent<MakRraycastHitForTableCell>().CheckNextCell();
                int emptyCellCount = _tableCells[i].GetComponent<MakRraycastHitForTableCell>().emptyCell.Count;
                if (emptyCellCount > 0)
                {
                    
                    int listCount = _tableCells[i].GetComponent<MakRraycastHitForTableCell>().sprites.Count;
                    for (int w = 0; w < listCount; w++)
                    {
                        int firstSpriteInt = 0;
                        int secondSpriteInt = 0;
                        Sprite sprite = _tableCells[i].GetComponent<MakRraycastHitForTableCell>().sprites[w];
                        if (sprite==_firstSprite)
                        {
                            firstSpriteInt++;
                        }
                        if (sprite==_secondSprite)
                        {
                            secondSpriteInt++;
                        }
                        if (gameManagerSC.hardMod)
                        {
                            if (firstSpriteInt>0 && secondSpriteInt>0)
                            {
                                settledDownInt++;
                            }
                        }
                        else
                        {
                            if (firstSpriteInt>0 || secondSpriteInt>0)
                            {
                                settledDownInt++;
                            }
                        }
                    }
                    
                    
                }
            }
        }
        Debug.Log(settledDownInt +" settle");
        if (settledDownInt < 1)
        {
            Debug.Log("*** GAME OVER ***");

        }
    }

}
