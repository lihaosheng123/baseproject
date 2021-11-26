using Game.Ctrl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.View
{
    public class StoreWindow : BaseWindow
    {
        public StoreWindow()
        {
            resName = "UI/Window/StoreWindow";
            resident = true;
            selfType = WindowType.StoreWindow;
            scenesType = ScenesType.Login;
        }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnAddListener()
        {
            base.OnAddListener();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void OnRemoveListener()
        {
            base.OnRemoveListener();
        }

        protected override void RegisterUIEvent()
        {
            base.RegisterUIEvent();
            foreach (var button in buttonList)
            {
                switch (button.name)
                {
                    case "BuyButton":
                        button.onClick.AddListener(OnBuyButtonClick);
                        break;
                }
            }
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            if (Input.GetKeyDown(KeyCode.C))
            {
                Close();
            }
        }


        private void OnBuyButtonClick()
        {
            Debug.Log("BuyButton click");

            Prop tempprop = new Prop
            {
                id = 1001,
                name = "test",
                price = 1,
                describe = "aaaa"
            };
            StoreCtrl.Instance.SaveProp(tempprop);
            var propdata = StoreCtrl.Instance.GetProp(1001);
            Debug.Log(propdata.name);
            foreach (var text in textList)
            {
                switch (text.name)
                {
                    case "count":
                        text.text = propdata.name;
                        break;
                }
            }
        }
    }
}
