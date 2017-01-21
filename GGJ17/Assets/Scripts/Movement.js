 #pragma strict
 
//Inspector Variables
public var playerSpeed : float = 10; //speed player moves
public var player1: GameObject;
public var player2: GameObject;
function Update () 
{
   
    MoveForward(); // Player Movement 

}
   
function MoveForward()
{
   
    if(Input.GetKey(KeyCode.UpArrow))//Press up arrow key to move forward on the Y AXIS
    {
        player1.transform.Translate(0,0,playerSpeed * Time.deltaTime);
    }
    if(Input.GetKey(KeyCode.DownArrow))//Press up arrow key to move forward on the Y AXIS
    {
        player1.transform.Translate(0,0,-playerSpeed * Time.deltaTime);
    }
    if(Input.GetKey(KeyCode.LeftArrow))//Press up arrow key to move forward on the Y AXIS
    {
        player1.transform.Translate(-playerSpeed * Time.deltaTime,0 ,0);
    }
    if(Input.GetKey(KeyCode.RightArrow))//Press up arrow key to move forward on the Y AXIS
    {
        player1.transform.Translate(playerSpeed * Time.deltaTime,0 ,0);
    }

    if(Input.GetKey(KeyCode.W))//Press up arrow key to move forward on the Y AXIS
    {
        player2.transform.Translate(0,0,playerSpeed * Time.deltaTime);
    }
    if(Input.GetKey(KeyCode.S))//Press up arrow key to move forward on the Y AXIS
    {
        player2.transform.Translate(0,0,-playerSpeed * Time.deltaTime);
    }
    if(Input.GetKey(KeyCode.A))//Press up arrow key to move forward on the Y AXIS
    {
        player2.transform.Translate(-playerSpeed * Time.deltaTime,0 ,0);
    }
    if(Input.GetKey(KeyCode.D))//Press up arrow key to move forward on the Y AXIS
    {
        player2.transform.Translate(playerSpeed * Time.deltaTime,0 ,0);
    }
}
