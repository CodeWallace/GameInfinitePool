using UnityEngine;
using System.Collections;
//鼠标滑动方向
public enum SlideDir
{
    right,//向右
    left,//向左
    top,//向上
    bottom,//向下
    nullpoint//无方向
}
public class GameControl : MonoBehaviour
{
    public SlideDir dir = SlideDir.nullpoint;//定义一个枚举类型的共有变量，初始值为无方向

    void Update()
    {
        Move();
    }

    //检测鼠标滑动的方向
    private SlideDir CheckDir()
    {

        if (Input.GetMouseButtonUp(0))
        {
            //print ("鼠标左键按下时的位置：" + DownPosition);
            print("鼠标左键抬起时的位置：" + Input.mousePosition);
            Vector3 offest = Input.mousePosition - DownPosition;//局部变量
            print("鼠标左键按下到抬起时的偏差：" + offest);

            //检测水平
            if (Mathf.Abs(offest.x) > 100 && Mathf.Abs(offest.x) >= Mathf.Abs(offest.y))
            {
                if (offest.x < 0)
                    dir = SlideDir.left;
                else
                    dir = SlideDir.right;
            }
            //检测竖直
            if (Mathf.Abs(offest.y) > 100 && Mathf.Abs(offest.x) < Mathf.Abs(offest.y))
            {
                if (offest.y > 0)
                    dir = SlideDir.top;
                else
                    dir = SlideDir.bottom;
            }
            //无方向
            if (Mathf.Abs(offest.x) <= 100 && Mathf.Abs(offest.y) <= 100)
                dir = SlideDir.nullpoint;
        }
        return dir;
    }


    private Vector3 DownPosition;


    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DownPosition = Input.mousePosition;

            print("鼠标左键按下时的位置：" + DownPosition);
        }
        if (Input.GetMouseButtonUp(0) == false)//只要没有鼠标抬起动作就退出
            return;
        SlideDir dir = CheckDir();//调用CheckDir（）函数获取方向
    }
}