﻿using OOPCConsoleProject.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCConsoleProject
{
    public static class Game
    {
        private static Dictionary<string, BaseScene> sceneDic;
        private static BaseScene curScene;

        private static bool gameOver;
        public static void Run()
        {
            Start();
            while (!gameOver)
            {
                Console.Clear();
                curScene.Render();
                curScene.Input();
                curScene.Update();
                curScene.Result();
            }

            End();
        }

        public static void ChangeScene(string sceneName)
        {
            curScene = sceneDic[sceneName];
        }

        /// <summary>
        /// 게임의 초기 작업 진행
        /// </summary>
        private static void Start()
        {
            // 게임 설정
            gameOver = false;

            // 씬 설정
            sceneDic = new Dictionary<string, BaseScene>();
            sceneDic.Add("Title", new TitleScene());
            sceneDic.Add("Test01", new TestScene01());
            sceneDic.Add("Test02", new TestScene02());
            sceneDic.Add("Test03", new TestScene03());
            ChangeScene("Title");
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
