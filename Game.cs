using OOPCConsoleProject.Scene;
using OOPCConsoleProject.UI;
using OOPCConsoleProject.VarioutData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject
{
    public static class Game
    {
        private static BaseScene? curScene;
        private static string? prevSceneName;
        private static TextBox? textBox;
        private static Player? player;
        public static Player Player { get { return player!; } set { player = value; }  }

        public static string? PrevSceneName { get => prevSceneName; set => prevSceneName = value; }
        public static TextBox? TextBox { get => textBox; set => textBox = value; }

        private static bool gameOver;
        public static void Run()
        {
            Start();
            while (!gameOver)
            {
                Console.SetCursorPosition(0, 0);
                curScene!.Render();
                curScene.Input();
                curScene.Update();
                curScene.Result();
            }

            End();
        }

        public static void ChangeScene(string sceneName)
        {
            PrevSceneName = curScene!.map.Name;
            curScene.Exit();
            curScene = VariousData.SceneDic[sceneName];

            
            curScene.Enter();

        }

        /// <summary>
        /// 게임의 초기 작업 진행
        /// </summary>
        private static void Start()
        {
            // 게임 설정
            gameOver = false;
            Console.CursorVisible = false;
            textBox = new TextBox();
            // 게임에 잇는 모든 씬들을 보관하고 빠르게 찾아줄 용도로 쓸 자료구조
            _ = new VariousData();

            //플레이어 설정
            player = new Player("미정");
            

            // 씬 설정
            curScene = VariousData.SceneDic["Title"];

            
            
        }

        /// <summary>
        /// 게임의 마무리 작업 진행
        /// </summary>
        //
        private static void End()
        {

        }
    }
}
