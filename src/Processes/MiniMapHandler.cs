using TMPro;
using UnityEngine;
using static GlobalVariables;

public class MiniMapHandler : MonoBehaviour
{
    // Private variables
    private TMP_Text _display;
     
    private void Draw(Map map)
    {
        _display.text = "";

        for(var y = (int) Maps.MAP_HEIGHT*2-2; y >= 0; y--){
            if(y % 2 == 0){
                for(var x = 0; x < (int) Maps.MAP_WIDTH*2-1; x++){
                    if(x % 2 == 0){
                        if(map.GetRoom(x/2, y/2) == null){
                            _display.text += " ";
                        } else {
                            if (player.GetLocation().GetXY() == (x/2, y/2))
                            {
                                _display.text += "<color=red>O</color>";
                            }
                            else if (map.GetRoom(x/2, y/2).GetVisited())
                            {
                                _display.text += "O";
                            }
                            else
                            {
                                _display.text += " ";
                            }
                        }
                    } else {
                        if(
                            map.GetRoom((x-1)/2, y/2) != null 
                            && map.GetRoom((x-1)/2, y/2).GetConnection((int) Directions.EAST) != null 
                            && (map.GetRoom((x-1)/2, y/2).GetVisited() || map.GetRoom((x-1)/2, y/2).GetConnection((int) Directions.EAST).GetVisited())
                            && (map.GetRoom((x-1)/2, y/2).GetDiscovered() || map.GetRoom((x-1)/2, y/2).GetVisited()) 
                            && (map.GetRoom((x-1)/2, y/2).GetConnection((int) Directions.EAST).GetDiscovered() || map.GetRoom((x-1)/2, y/2).GetConnection((int) Directions.EAST).GetVisited())){
                            _display.text += "-";
                        } else {
                            _display.text += " ";
                        }
                    }
                }
            } else if (y != 0 && y != (int) Maps.MAP_HEIGHT*2-1){
                for(int x = 0; x <= (int) Maps.MAP_WIDTH-1; x++){
                    if(map.GetRoom(x, (y-1)/2) != null 
                       && map.GetRoom(x, (y-1)/2).GetConnection((int) Directions.NORTH) != null
                       && (map.GetRoom(x, (y-1)/2).GetVisited() || map.GetRoom(x, (y-1)/2).GetConnection((int) Directions.NORTH).GetVisited())
                       && (map.GetRoom(x, (y-1)/2).GetDiscovered() || map.GetRoom(x, (y-1)/2).GetVisited()) 
                       && (map.GetRoom(x, (y-1)/2).GetConnection((int) Directions.NORTH).GetDiscovered() || map.GetRoom(x, (y-1)/2).GetConnection((int) Directions.NORTH).GetVisited())){
                        _display.text += "| ";
                    } else {
                        _display.text += "  ";
                    }
                }
            }
            _display.text += '\n';
        }
    }

    // Public variables
    
    // Start is called before the first frame update
    public void Awake()
    {
        _display = gameObject.GetComponent<TMP_Text>();
    }
    
    // Update is called once per frame
    public void Update()
    {
        if (!DoUpdateMapDisplay) return;
        Draw(GameMap[CurrentLevel]);
        DoUpdateMapDisplay = false;
    }
}
