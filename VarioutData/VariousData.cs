using OOPCConsoleProject.GameObjects;
using OOPCConsoleProject.VarioutData.Items;
using OOPCConsoleProject.Scene;
using OOPCConsoleProject.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPCConsoleProject.VarioutData
{
    class VariousData
    {
        private static Dictionary<string, BaseScene>? sceneDic;
        private static Dictionary<string, Map>? mapDic;
        private static Dictionary<string, Monster>? monsDic;
        private static Dictionary<string, NPC>? npcDic;
        private static Dictionary<string, Item>? itemDic;
        public static Dictionary<string, BaseScene> SceneDic { get { return sceneDic!; } set { sceneDic = value; } }
        public static Dictionary<string, Map> MapDic { get { return mapDic!; } set { mapDic = value; } }
        public static Dictionary<string, Monster> MonsDic { get { return monsDic!; } set { monsDic = value; } }
        public static Dictionary<string, NPC> NpcDic { get { return npcDic!; } set { npcDic = value; } }
        public static Dictionary<string, Item> ItemDic { get { return itemDic!; } set { itemDic = value; } }


        public VariousData()
        {
            sceneDic = [];
            mapDic = [];
            monsDic = [];
            npcDic = [];
            itemDic = [];
            MakeMap();
            MakeNPC();
            NPCLinkedMap();
            MakeNPCobj();
            MakeMonster();
            MonsterLinkedMap();
            MakeItem();
            ItemLinked();
            sceneDic.Add("Title", new TitleScene());
            sceneDic.Add("CreationChar", new CreationCharScene());
            //sceneDic.Add("Field", new FieldScene());
        }
        public static void MakeMap()
        {
            mapDic!.Add("버섯마을서쪽입구", new Map("버섯마을서쪽입구", MapType.마을));
            mapDic["버섯마을서쪽입구"].AddGO(new Place("버섯마을I", new Vector2(8, 5)));
            mapDic["버섯마을서쪽입구"].SetMapTile("버섯마을서쪽입구");
            
            mapDic!.Add("버섯마을I", new Map("버섯마을I", MapType.마을));
            mapDic["버섯마을I"].AddGO(new Place("버섯마을서쪽입구", new Vector2(1, 4)));
            mapDic["버섯마을I"].AddGO(new Place("버섯마을II", new Vector2(8, 5)));
            mapDic["버섯마을I"].SetMapTile("버섯마을I");

            mapDic!.Add("버섯마을II", new Map("버섯마을II", MapType.마을));
            mapDic["버섯마을II"].AddGO(new Place("버섯마을I", new Vector2(1, 4)));
            mapDic["버섯마을II"].AddGO(new Place("버섯마을민가", new Vector2(6, 3)));
            mapDic["버섯마을II"].AddGO(new Place("버섯마을동쪽입구", new Vector2(8, 5)));
            mapDic["버섯마을II"].SetMapTile("버섯마을II");

            mapDic!.Add("버섯마을민가", new Map("버섯마을민가", MapType.마을));
            mapDic["버섯마을민가"].AddGO(new Place("버섯마을II", new Vector2(4, 7)));
            mapDic["버섯마을민가"].SetMapTile("버섯마을민가");

            mapDic!.Add("버섯마을동쪽입구", new Map("버섯마을동쪽입구", MapType.사냥터));
            mapDic["버섯마을동쪽입구"].AddGO(new Place("버섯마을II", new Vector2(0, 9)));
            mapDic["버섯마을동쪽입구"].AddGO(new Place("달팽이사냥터I", new Vector2(9, 0)));
            mapDic["버섯마을동쪽입구"].SetMapTile("버섯마을동쪽입구");

            mapDic!.Add("달팽이사냥터I", new Map("달팽이사냥터I", MapType.사냥터));
            mapDic["달팽이사냥터I"].AddGO(new Place("버섯마을동쪽입구", new Vector2(0, 9)));
            mapDic["달팽이사냥터I"].AddGO(new Place("달팽이사냥터II", new Vector2(9, 9)));
            mapDic["달팽이사냥터I"].SetMapTile("달팽이사냥터I");

            mapDic!.Add("달팽이사냥터II", new Map("달팽이사냥터II", MapType.사냥터));
            mapDic["달팽이사냥터II"].AddGO(new Place("달팽이사냥터I", new Vector2(0, 9)));
            mapDic["달팽이사냥터II"].AddGO(new Place("달팽이사냥터III", new Vector2(9, 9)));
            mapDic["달팽이사냥터II"].SetMapTile("달팽이사냥터II");

            mapDic!.Add("달팽이사냥터III", new Map("달팽이사냥터III", MapType.사냥터));
            mapDic["달팽이사냥터III"].AddGO(new Place("달팽이사냥터II", new Vector2(0, 9)));
            mapDic["달팽이사냥터III"].AddGO(new Place("두갈래길", new Vector2(9, 0)));
            mapDic["달팽이사냥터III"].SetMapTile("달팽이사냥터III");

            mapDic!.Add("두갈래길", new Map("두갈래길", MapType.사냥터));
            mapDic["두갈래길"].AddGO(new Place("달팽이사냥터III", new Vector2(0, 5)));
            mapDic["두갈래길"].AddGO(new Place("암허스트서쪽필드", new Vector2(9, 0)));
            mapDic["두갈래길"].AddGO(new Place("사우스페리서쪽필드", new Vector2(9, 9)));
            mapDic["두갈래길"].SetMapTile("두갈래길");

            mapDic!.Add("암허스트서쪽필드", new Map("암허스트서쪽필드", MapType.사냥터));
            mapDic["암허스트서쪽필드"].AddGO(new Place("두갈래길", new Vector2(0, 9)));
            mapDic["암허스트서쪽필드"].AddGO(new Place("암허스트", new Vector2(9, 3)));
            mapDic["암허스트서쪽필드"].SetMapTile("암허스트서쪽필드");

            mapDic!.Add("암허스트", new Map("암허스트", MapType.마을));
            mapDic["암허스트"].AddGO(new Place("암허스트서쪽필드", new Vector2(0, 6)));
            mapDic["암허스트"].AddGO(new Place("암허스트동쪽필드", new Vector2(9, 9)));
            mapDic["암허스트"].SetMapTile("암허스트");

            mapDic!.Add("암허스트동쪽필드", new Map("암허스트동쪽필드", MapType.사냥터));
            mapDic["암허스트동쪽필드"].AddGO(new Place("암허스트", new Vector2(0, 0)));
            mapDic["암허스트동쪽필드"].SetMapTile("암허스트동쪽필드");

            mapDic!.Add("사우스페리서쪽필드", new Map("사우스페리서쪽필드", MapType.사냥터));
            mapDic["사우스페리서쪽필드"].AddGO(new Place("두갈래길", new Vector2(0, 0)));
            mapDic["사우스페리서쪽필드"].AddGO(new Place("사우스페리", new Vector2(9, 6)));
            mapDic["사우스페리서쪽필드"].SetMapTile("사우스페리서쪽필드");

            mapDic!.Add("사우스페리", new Map("사우스페리", MapType.마을));
            mapDic["사우스페리"].AddGO(new Place("사우스페리서쪽필드", new Vector2(0, 6)));
            mapDic["사우스페리"].SetMapTile("사우스페리");

            Map.LinkedMap(mapDic["버섯마을서쪽입구"], mapDic["버섯마을I"]);
            Map.LinkedMap(mapDic["버섯마을I"], mapDic["버섯마을II"]);
            Map.LinkedMap(mapDic["버섯마을II"], mapDic["버섯마을민가"]);
            Map.LinkedMap(mapDic["버섯마을II"], mapDic["버섯마을동쪽입구"]);
            Map.LinkedMap(mapDic["버섯마을동쪽입구"], mapDic["달팽이사냥터I"]);
            Map.LinkedMap(mapDic["달팽이사냥터I"], mapDic["달팽이사냥터II"]);
            Map.LinkedMap(mapDic["달팽이사냥터II"], mapDic["달팽이사냥터III"]);
            Map.LinkedMap(mapDic["달팽이사냥터III"], mapDic["두갈래길"]);
            Map.LinkedMap(mapDic["두갈래길"], mapDic["암허스트서쪽필드"]);
            Map.LinkedMap(mapDic["두갈래길"], mapDic["사우스페리서쪽필드"]);
            Map.LinkedMap(mapDic["암허스트서쪽필드"], mapDic["암허스트"]);
            Map.LinkedMap(mapDic["암허스트"], mapDic["암허스트동쪽필드"]);
            Map.LinkedMap(mapDic["사우스페리서쪽필드"], mapDic["사우스페리"]); Map.LinkedMap(mapDic["달팽이사냥터III"], mapDic["두갈래길"]);


            foreach (var s in mapDic)
            {
                //if (s.Value.MapType == MapType.마을)
                //    sceneDic.Add(s.Key, new TownScene(s.Value));
                //else
                //    sceneDic.Add(s.Key, new FieldScene(s.Value));
                sceneDic!.Add(s.Key, new FieldScene(s.Value));
            }
        }

        public static void MakeNPC()
        {
            npcDic!.Add("히나", new NPC("히나", new Vector2(2,3)));
            npcDic["히나"].Addspeech("메이플 아일랜드에 온걸 환영해");
            npcDic.Add("세라", new NPC("세라", new Vector2(7, 4)));
            npcDic["세라"].Addspeech("난 왜이리 예쁜걸까");
            npcDic.Add("로저", new NPC("로저", new Vector2(5, 3)));
            npcDic["로저"].Addspeech("사과 한번 먹어봐");
            npcDic.Add("다나", new NPC("다나", new Vector2(3, 3)));
            npcDic["다나"].Addspeech("내 동생에게 버섯 사탕을 갖다 줘");
            npcDic.Add("센", new NPC("센", new Vector2(4, 4)));
            npcDic["센"].Addspeech("배고파");
            npcDic.Add("토드", new NPC("토드", new Vector2(1, 7)));
            npcDic["토드"].Addspeech("사냥하는 법을 알아볼까?");
            npcDic.Add("피터", new NPC("피터", new Vector2(7, 0)));
            npcDic["피터"].Addspeech("이 앞은 위험한 달팽이들이 있어");
            npcDic.Add("로빈", new NPC("로빈", new Vector2(0, 7)));
            npcDic["로빈"].Addspeech("달팽이를 잡아볼까?");
            npcDic.Add("쌤", new NPC("쌤", new Vector2(9, 7)));
            npcDic["쌤"].Addspeech("로빈이 잡으라는 달팽이는 다 잡았어?");
            npcDic.Add("마리아", new NPC("마리아", new Vector2(3, 3)));
            npcDic["마리아"].Addspeech("편지를 전달해야하는데");
            npcDic.Add("레인", new NPC("레인", new Vector2(1, 4)));
            npcDic["레인"].Addspeech("퀴즈 맞출래?");
            npcDic.Add("피오", new NPC("피오", new Vector2(5, 4)));
            npcDic["피오"].Addspeech("새로운 의자를 개발하고 있어");
            npcDic.Add("장로 루카스", new NPC("장로 루카스", new Vector2(5, 8)));
            npcDic["장로 루카스"].Addspeech("마리아가 줄 편지가 있었는데..");
            npcDic.Add("빅스", new NPC("빅스", new Vector2(5, 2)));
            npcDic["빅스"].Addspeech("강한 무기를 얻고 싶어?");
            npcDic.Add("샹크스", new NPC("샹크스", new Vector2(9, 7)));
            npcDic["샹크스"].Addspeech("배 출항까지는 좀 걸립니다.");

        }

        public static void NPCLinkedMap()
        {
            mapDic!["버섯마을서쪽입구"].Npcs.Add(npcDic!["히나"]);
            mapDic["버섯마을서쪽입구"].Npcs.Add(npcDic["세라"]);
            mapDic["버섯마을I"].Npcs.Add(npcDic["로저"]);
            mapDic["버섯마을II"].Npcs.Add(npcDic["다나"]);
            mapDic["버섯마을민가"].Npcs.Add(npcDic["센"]);
            mapDic["버섯마을동쪽입구"].Npcs.Add(npcDic["토드"]);
            mapDic["버섯마을동쪽입구"].Npcs.Add(npcDic["피터"]);
            mapDic["달팽이사냥터I"].Npcs.Add(npcDic["로빈"]);
            mapDic["달팽이사냥터I"].Npcs.Add(npcDic["쌤"]);
            mapDic["두갈래길"].Npcs.Add(npcDic["마리아"]);
            mapDic["암허스트"].Npcs.Add(npcDic["레인"]);
            mapDic["암허스트"].Npcs.Add(npcDic["피오"]);
            mapDic["암허스트"].Npcs.Add(npcDic["장로 루카스"]);
            mapDic["사우스페리"].Npcs.Add(npcDic["빅스"]);
            mapDic["사우스페리"].Npcs.Add(npcDic["샹크스"]);

            //mapDic["버섯마을서쪽입구"].MapInNPC();
            //mapDic["버섯마을I"].MapInNPC();
            //mapDic["버섯마을II"].MapInNPC();
            //mapDic["버섯마을민가"].MapInNPC();
            //mapDic["버섯마을동쪽입구"].MapInNPC();
            //mapDic["달팽이사냥터I"].MapInNPC();
            //mapDic["두갈래길"].MapInNPC();
            //mapDic["암허스트"].MapInNPC();
            //mapDic["사우스페리"].MapInNPC();
            foreach(var obj in mapDic)
            {
                obj.Value.MapInNPC();
            }
        }

        public static void MakeNPCobj()
        {
            foreach (var map in mapDic!)
            {
                map.Value.AddNPC();
            }
        }

        public static void MakeMonster()
        {
            monsDic!.Add("달팽이", new Monster("달팽이", 1, 8, 12, 1, 3, 2));
            monsDic.Add("스포아", new Monster("스포아", 2, 20, 17, 3, 5, 3));
            monsDic.Add("파란 달팽이", new Monster("파란 달팽이", 2, 15, 17, 2, 4, 5));
            monsDic.Add("빨간 달팽이", new Monster("빨간 달팽이", 4, 45, 35, 3, 8, 7));
            monsDic.Add("슬라임", new Monster("슬라임", 6, 50, 6, 42, 10, 10));
            monsDic.Add("돼지", new Monster("돼지", 7, 75, 52, 15, 15, 15));
            monsDic.Add("주황버섯", new Monster("주황버섯", 8, 80, 52, 13, 20, 20));

            monsDic["달팽이"].SetMonsterShape("달팽이");
            monsDic["스포아"].SetMonsterShape("스포아");
            monsDic["파란 달팽이"].SetMonsterShape("파란 달팽이");
            monsDic["빨간 달팽이"].SetMonsterShape("빨간 달팽이");
            monsDic["슬라임"].SetMonsterShape("슬라임");
            monsDic["돼지"].SetMonsterShape("돼지");
            monsDic["주황버섯"].SetMonsterShape("주황버섯");
        }

        public static void MonsterLinkedMap()
        {
            mapDic!["버섯마을동쪽입구"].Monsters.Add(monsDic!["달팽이"]);

            mapDic["달팽이사냥터I"].Monsters.Add(monsDic["달팽이"]);
            mapDic["달팽이사냥터I"].Monsters.Add(monsDic["파란 달팽이"]);

            mapDic["달팽이사냥터II"].Monsters.Add(monsDic["달팽이"]);
            mapDic["달팽이사냥터II"].Monsters.Add(monsDic["파란 달팽이"]);

            mapDic["달팽이사냥터III"].Monsters.Add(monsDic["달팽이"]);
            mapDic["달팽이사냥터III"].Monsters.Add(monsDic["파란 달팽이"]);
            mapDic["달팽이사냥터III"].Monsters.Add(monsDic["빨간 달팽이"]);

            mapDic["두갈래길"].Monsters.Add(monsDic["파란 달팽이"]);
            mapDic["두갈래길"].Monsters.Add(monsDic["스포아"]);
            mapDic["두갈래길"].Monsters.Add(monsDic["빨간 달팽이"]);

            mapDic["암허스트서쪽필드"].Monsters.Add(monsDic["파란 달팽이"]);
            mapDic["암허스트서쪽필드"].Monsters.Add(monsDic["스포아"]);
            mapDic["암허스트서쪽필드"].Monsters.Add(monsDic["빨간 달팽이"]);
            mapDic["암허스트서쪽필드"].Monsters.Add(monsDic["슬라임"]);

            mapDic["암허스트동쪽필드"].Monsters.Add(monsDic["파란 달팽이"]);
            mapDic["암허스트동쪽필드"].Monsters.Add(monsDic["스포아"]);
            mapDic["암허스트동쪽필드"].Monsters.Add(monsDic["돼지"]);
            mapDic["암허스트동쪽필드"].Monsters.Add(monsDic["주황버섯"]);

            mapDic["사우스페리서쪽필드"].Monsters.Add(monsDic["파란 달팽이"]);
            mapDic["사우스페리서쪽필드"].Monsters.Add(monsDic["빨간 달팽이"]);
            mapDic["사우스페리서쪽필드"].Monsters.Add(monsDic["슬라임"]);
            mapDic["사우스페리서쪽필드"].Monsters.Add(monsDic["돼지"]);
        }

        public static void MakeItem()
        {
            // 기타 템
            itemDic!.Add("달팽이의 껍질", new OtherItem("달팽이의 껍질", "달팽이의 껍질을 벗긴 것이다.", 2, 2));
            itemDic.Add("파란 달팽이의 껍질", new OtherItem("파란 달팽이의 껍질", "파란 달팽이의 껍질을 벗긴 것이다.", 3, 4));
            itemDic.Add("빨간 달팽이의 껍질", new OtherItem("빨간 달팽이의 껍질", "빨간 달팽이의 껍질을 벗긴 것이다.", 4, 5));
            itemDic.Add("버섯의 포자", new OtherItem("버섯의 포자", "버섯의 포자이다.", 2, 2));
            itemDic.Add("물컹물컹한 액체", new OtherItem("물컹물컹한 액체", "점성이 높아 끈적끈적한 액체이다.", 4, 10));
            itemDic.Add("슬라임의 방울", new OtherItem("슬라임의 방울", "슬라임의 방울을 떼어온 것이다.", 50, 100));
            itemDic.Add("돼지의 머리", new OtherItem("돼지의 머리", "돼지의 머리이다.", 100, 200));
            itemDic.Add("동물의 가죽", new OtherItem("동물의 가죽", "동물의 가죽", 60, 30));
            itemDic.Add("주황버섯의 갓", new OtherItem("주황버섯의 갓", "주황버섯의 갓을 자른 것이다.", 4, 20));

            // 포션
            itemDic.Add("사과", new Potion("사과", "빨갛게 잘 익은 사과이다. HP 30을 회복 시킨다.", 30, 20, 5));
            itemDic.Add("빨간 포션", new Potion("빨간 포션", "붉은 약초로 만든 물약이다. HP 100을 회복 시킨다.", 100, 30, 15));
            itemDic.Add("주황 포션", new Potion("주황 포션", "붉은 약초의 농축 물약이다. HP 150를 회복 시킨다.", 150, 50, 25));


            // 장비
            // 머리
            itemDic.Add("연두색 머리띠", new Equipment("연두색 머리띠", Part.머리, 20, 100, 10));
            itemDic.Add("흰색 두건", new Equipment("흰색 두건", Part.머리, 30, 100, 30));
            itemDic.Add("갈색 가죽 모자", new Equipment("갈색 가죽 모자", Part.머리, 50, 1000, 50));
            itemDic.Add("브론즈 코이프", new Equipment("브론즈 코이프", Part.머리, 100, 5000, 150));

            //전신
            itemDic.Add("일상복", new Equipment("일상복", Part.전신, 5, 100, 30));
            itemDic.Add("회색 수련복", new Equipment("회색 수련복", Part.전신, 10, 150, 50));
            itemDic.Add("검은 은신복", new Equipment("검은 은신복", Part.전신, 13, 1000, 100));
            itemDic.Add("갈색 가죽갑옷", new Equipment("갈색 가죽갑옷", Part.전신, 20, 1500, 150));

            //신발
            itemDic.Add("브라운 우드탑", new Equipment("브라운 우드탑", Part.신발, 2, 200, 10));
            itemDic.Add("베이지 니티", new Equipment("베이지 니티", Part.신발, 3, 300, 30));
            itemDic.Add("흰색 고무신", new Equipment("흰색 고무신", Part.신발, 5, 1000, 40));
            itemDic.Add("하드래더 부츠", new Equipment("하드래더 부츠", Part.신발, 6, 2000, 60));
            itemDic.Add("닌자 샌들", new Equipment("닌자 샌들", Part.신발, 8, 2500, 200));

            //무기
            itemDic.Add("검", new Equipment("검", Part.무기, 3, 100, 10));
            itemDic.Add("필드 대거", new Equipment("필드 대거", Part.무기, 10, 1000, 50));
            itemDic.Add("가죽 핸드백", new Equipment("가죽 핸드백", Part.무기, 15, 3000, 1500));
            itemDic.Add("메탈 완드", new Equipment("메탈 완드", Part.무기, 10, 1000, 50));
            itemDic.Add("목검", new Equipment("목검", Part.무기, 10, 500, 300));
            itemDic.Add("나무 망치", new Equipment("나무 망치", Part.무기, 15, 200, 200));
            itemDic.Add("쇠 도끼", new Equipment("쇠 도끼", Part.무기, 15, 200, 300));
            itemDic.Add("철제 도끼", new Equipment("철제 도끼", Part.무기, 30, 5000, 3000));
            itemDic.Add("양날 도끼", new Equipment("양날 도끼", Part.무기, 17, 200, 500));
            itemDic.Add("창", new Equipment("창", Part.무기, 12, 200, 300));
            itemDic.Add("포크 창", new Equipment("포크 창", Part.무기, 17, 1000, 1000));
            itemDic.Add("가니어", new Equipment("가니어", Part.무기, 9, 2000, 1500));


        }

        public static void ItemLinked()
        {
            monsDic!["달팽이"].items.Add(itemDic!["달팽이의 껍질"]);
            monsDic["달팽이"].items.Add(itemDic["사과"]);
            monsDic["달팽이"].items.Add(itemDic["연두색 머리띠"]);

            monsDic["스포아"].items.Add(itemDic["버섯의 포자"]);
            monsDic["스포아"].items.Add(itemDic["사과"]);
            monsDic["스포아"].items.Add(itemDic["일상복"]);
            monsDic["스포아"].items.Add(itemDic["필드 대거"]);

            monsDic["파란 달팽이"].items.Add(itemDic["파란 달팽이의 껍질"]);
            monsDic["파란 달팽이"].items.Add(itemDic["사과"]);
            monsDic["파란 달팽이"].items.Add(itemDic["일상복"]);
            monsDic["파란 달팽이"].items.Add(itemDic["회색 수련복"]);

            monsDic["빨간 달팽이"].items.Add(itemDic["빨간 달팽이의 껍질"]);
            monsDic["빨간 달팽이"].items.Add(itemDic["빨간 포션"]);
            monsDic["빨간 달팽이"].items.Add(itemDic["브라운 우드탑"]);
            monsDic["빨간 달팽이"].items.Add(itemDic["가죽 핸드백"]);
            monsDic["빨간 달팽이"].items.Add(itemDic["메탈 완드"]);
            monsDic["빨간 달팽이"].items.Add(itemDic["목검"]);

            monsDic["슬라임"].items.Add(itemDic["물컹물컹한 액체"]);
            monsDic["슬라임"].items.Add(itemDic["슬라임의 방울"]);
            monsDic["슬라임"].items.Add(itemDic["빨간 포션"]);
            monsDic["슬라임"].items.Add(itemDic["흰색 두건"]);
            monsDic["슬라임"].items.Add(itemDic["베이지 니티"]);
            monsDic["슬라임"].items.Add(itemDic["쇠 도끼"]);
            monsDic["슬라임"].items.Add(itemDic["철제 도끼"]);
            monsDic["슬라임"].items.Add(itemDic["포크 창"]);


            monsDic["돼지"].items.Add(itemDic["돼지의 머리"]);
            monsDic["돼지"].items.Add(itemDic["동물의 가죽"]);
            monsDic["돼지"].items.Add(itemDic["빨간 포션"]);
            monsDic["돼지"].items.Add(itemDic["갈색 가죽 모자"]);
            monsDic["돼지"].items.Add(itemDic["검은 은신복"]);
            monsDic["돼지"].items.Add(itemDic["갈색 가죽갑옷"]);
            monsDic["돼지"].items.Add(itemDic["나무 망치"]);
            monsDic["돼지"].items.Add(itemDic["가니어"]);

            monsDic["주황버섯"].items.Add(itemDic["버섯의 포자"]);
            monsDic["주황버섯"].items.Add(itemDic["주황버섯의 갓"]);
            monsDic["주황버섯"].items.Add(itemDic["주황 포션"]);
            monsDic["주황버섯"].items.Add(itemDic["브론즈 코이프"]);
            monsDic["주황버섯"].items.Add(itemDic["흰색 고무신"]);
            monsDic["주황버섯"].items.Add(itemDic["하드래더 부츠"]);
            monsDic["주황버섯"].items.Add(itemDic["닌자 샌들"]);
            monsDic["주황버섯"].items.Add(itemDic["양날 도끼"]);
            monsDic["주황버섯"].items.Add(itemDic["창"]);

            mapDic!["버섯마을I"].AddGO(new ItemBox(new Vector2(4, 3), itemDic["사과"]));
        }
    }
}
