using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using YG;

public class MainCkript : MonoBehaviour
{
    public long _clickMoney = 1;
    public long _money;
    public long _moneyPerSecond = 0;
    public Text MoneyText;
    public Text SecondMoneyText;
    public Text ClickMoneyText;
    [SerializeField] public GameObject[] Improvements;
    [SerializeField] public GameObject[] Locks;

    [SerializeField] GameObject _Plag;
    [SerializeField] GameObject _menuBuy;

    public Sprite onMusic;
    public Sprite offMusic;

    public Image MusicButton;
    public bool isOn;
    public AudioSource ad;

    public Image Backgraund;
    public Image Person;
    [SerializeField] public Sprite[] BackSprite;
    /*public Sprite B2;
    public Sprite B3;
    public Sprite B4;*/
    [SerializeField] public Sprite[] PersSprite;
    /*public Sprite P2;
    public Sprite P3;
    public Sprite P4;*/

    private bool personSpriteLoaded1 = false;
    private bool personSpriteLoaded2 = false;
    private bool personSpriteLoaded3 = false;
    private bool personSpriteLoaded4 = false;
    private bool backgroundSpriteLoaded1 = false;
    private bool backgroundSpriteLoaded2 = false;
    private bool backgroundSpriteLoaded3 = false;
    private bool backgroundSpriteLoaded4 = false;

    public string[] Format_name = new[]
    {
        "", "K", "M", "I", "B", "S"//, "L", "F", "I", "D", "H", "J"
    };

    public string FarmatNamber(float num)
    {
        if (num == 0)
            return "0";

        sbyte i = 0;
        while (i+1 < Format_name.Length && num >= 1000f)
        {
            num /= 1000f;
            i++;
        }
        return num.ToString("#.##") + Format_name[i];
    }

    void Start()
    {
        _money = long.Parse(PlayerPrefs.GetString("Money", "0"));
        _clickMoney = long.Parse(PlayerPrefs.GetString("ClickMoney", "1"));
        _moneyPerSecond = long.Parse(PlayerPrefs.GetString("MoneyPerSecond", "0"));
        StartCoroutine(BonusShop());
        StartCoroutine(My_Save());
        Invoke("PlayCoruntikool", 80f);
        CheckLocks();
        isOn = true;
    }

    
    void Update()
    {
        //MoneyText.text = _money + "";

        MoneyText.text = FarmatNamber(_money);
        SecondMoneyText.text = FarmatNamber(_moneyPerSecond);
        ClickMoneyText.text = FarmatNamber(_clickMoney);
        /*if (_money == 15 || _money == 100 || _money == 1500 || _money == 10000 || _money == 110000
            || _money == 1000000 || _money == 15000000 || _money == 200000000 || _money == 3000000000 || _money == 50000000000
            || _money == 750000000000 || _money == 10000000000000 || _money == 250000000000000)
            CheckLocks();*/
        if (PlayerPrefs.GetInt("music") == 0)
        {
            MusicButton.GetComponent<Image>().sprite = onMusic;
            ad.enabled = true;
            isOn = true;
        }
        else if (PlayerPrefs.GetInt("music") == 1)
        {
            MusicButton.GetComponent<Image>().sprite = offMusic;
            ad.enabled = false;
            isOn = false;
        }
        CheckLocks();
        ChekProgressP();
        ChekProgressB();
    }
    public void OnClickButton()
    {
        _money += _clickMoney;
    }
    /*public void BuyingUpgrades()
    {
            if (Improvements[0] && _money >= 15) { 
                _money -= 15;
                _moneyPerSecond += 1;}
            if (Improvements[1] && _money >= 100) { 
                _money -= 100;
                _clickMoney += 1;}
            if (Improvements[2] && _money >= 1500) { 
                _money -= 1500;
                _moneyPerSecond += 25;}
            if (Improvements[3] && _money >= 10000) { 
                _money -= 10000;
                _clickMoney += 50;}
            if (Improvements[4] && _money >= 110000) { 
                _money -= 110000;
                _moneyPerSecond += 2000;}
            if (Improvements[5] && _money >= 1000000) { 
                _money -= 1000000;
                _moneyPerSecond += 25000;}
            if (Improvements[6] && _money >= 15000000) { 
                _money -= 15000000;
                _moneyPerSecond += 200000;}
            if (Improvements[7] && _money >= 200000000) { 
                _money -= 200000000;
                _clickMoney += 500000;}
            if (Improvements[8] && _money >= 3000000000) { 
                _money -= 3000000000;
                _moneyPerSecond += 45000000;}
            if (Improvements[9] && _money >= 50000000000) { 
                _money -= 50000000000;
                _moneyPerSecond += 650000000;}
            if (Improvements[10] && _money >= 750000000000) { 
                _money -= 750000000000;
                _clickMoney += 800000000;}
            if (Improvements[11] && _money >= 10000000000000) { 
                _money -= 10000000000000;
                _moneyPerSecond += 10000000000;}
            if (Improvements[12] && _money >= 250000000000000){
                _money -= 250000000000000;
                _moneyPerSecond += 300000000000;}
            if (Improvements[13] && _money >= 5000000000000000){
                _money -= 5000000000000000;
                _moneyPerSecond += 10000000000000;
        } 
    }*/
    public void ButtonShop01()
    {
        if (_money >= 15)
        {
            _money -= 15;
            _moneyPerSecond += 1;
        }
    }
    public void ButtonShop02()
    {
        if (_money >= 100)
        {
            _money -= 100;
            _clickMoney += 1;
        }
    }
    public void ButtonShop03()
    {
        if (_money >= 1500)
        {
            _money -= 1500;
            _moneyPerSecond += 25;
        }
    }
    public void ButtonShop04()
    {
        if (_money >= 10000)
        {
            _money -= 10000;
            _clickMoney += 50;
        }
    }
    public void ButtonShop05()
    {
        if (_money >= 110000)
        {
            _money -= 110000;
            _moneyPerSecond += 2000;
        }
    }
    public void ButtonShop06()
    {
        if (_money >= 1000000)
        {
            _money -= 1000000;
            _moneyPerSecond += 25000;
        }
    }
    public void ButtonShop07()
    {
        if (_money >= 15000000)
        {
            _money -= 15000000;
            _moneyPerSecond += 200000;
        }
    }
    public void ButtonShop08()
    {
        if (_money >= 200000000)
        {
            _money -= 200000000;
            _clickMoney += 500000;
        }
    }
    public void ButtonShop09()
    {
        if (_money >= 3000000000)
        {
            _money -= 3000000000;
            _moneyPerSecond += 45000000;
        }
    }
    public void ButtonShop10()
    {
        if (_money >= 50000000000)
        {
            _money -= 50000000000;
            _moneyPerSecond += 650000000;
        }
    }
    public void ButtonShop11()
    {
        if (_money >= 750000000000)
        {
            _money -= 750000000000;
            _clickMoney += 800000000;
        }
    }
    public void ButtonShop12()
    {
        if (_money >= 10000000000000)
        {
            _money -= 10000000000000;
            _moneyPerSecond += 10000000000;
        }
    }
    public void ButtonShop13()
    {
        if (_money >= 250000000000000)
        {
            _money -= 250000000000000;
            _moneyPerSecond += 300000000000;
        }
    }
    public void ButtonShop14()
    {
        if (_money >= 5000000000000000)
        {
            _money -= 5000000000000000;
            _moneyPerSecond += 10000000000000;
        }
    }

    public void CheckLocks()
    {
        if (_money >= 15)
            Locks[0].SetActive(false);
        if (_money >= 100)
            Locks[1].SetActive(false);
        if (_money >= 1500)
            Locks[2].SetActive(false);
        if (_money >= 10000)
            Locks[3].SetActive(false);
        if (_money >= 110000)
            Locks[4].SetActive(false);
        if (_money >= 1000000)
            Locks[5].SetActive(false);
        if (_money >= 15000000)
            Locks[6].SetActive(false);
        if (_money >= 200000000)
            Locks[7].SetActive(false);
        if (_money >= 3000000000)
            Locks[8].SetActive(false);
        if (_money >= 50000000000)
            Locks[9].SetActive(false);
        if (_money >= 750000000000)
            Locks[10].SetActive(false);
        if (_money >= 10000000000000)
            Locks[11].SetActive(false);
        if (_money >= 250000000000000)
            Locks[12].SetActive(false);
    }

    IEnumerator BonusShop()
    {
        while (true)
        {
            _money += _moneyPerSecond;
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator My_Save()
    {
        while (true)
        {

            PlayerPrefs.SetString("Money", _money.ToString());
            PlayerPrefs.SetString("ClickMoney", _clickMoney.ToString());
            PlayerPrefs.SetString("MoneyPerSecond", _moneyPerSecond.ToString());

            YandexGame.savesData.money = (int)_money;
            YandexGame.savesData.money = (int)_clickMoney;
            YandexGame.savesData.money = (int)_moneyPerSecond;
            YandexGame.SaveProgress();
            yield return new WaitForSeconds(1);
        }
    }
    public void Advert()
    {
        _Plag.SetActive(false);
        YandexGame.FullscreenShow();
    }
    IEnumerator AdvertsDisplay()
    {
        while (true)
        {
            _Plag.SetActive(true);
            Invoke("Advert", 3f);
            yield return new WaitForSeconds(80);
        }
    }
    public void PlayCoruntikool()
    {
        StartCoroutine(AdvertsDisplay());
    }
    public void offSaund()
    {
        if (!isOn)
        {
            PlayerPrefs.SetInt("music", 0);
            YandexGame.savesData.money = 0;
        }
        else if (isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            YandexGame.savesData.money = 1;
        }
    }
    public void OpenMagazin()
    {
        _menuBuy.SetActive(true);
    }
    public void CloseMagazin()
    {
        _menuBuy.SetActive(false);
    }
    public void ChekProgressP()
    {
        switch (_money)
        {
            case >= 5000000000000000:
                if (!personSpriteLoaded1)
                {
                    Person.sprite = PersSprite[3];
                    personSpriteLoaded1 = true;
                }
                break;
            case >= 750000000000:
                if (!personSpriteLoaded2)
                {
                    Person.sprite = PersSprite[2];
                    personSpriteLoaded2 = true;
                }
                break;
            case >= 15000000:
                if (!personSpriteLoaded3)
                {
                    Person.sprite = PersSprite[1];
                    personSpriteLoaded3 = true;
                }
                break;
            case >= 10000:
                if (!personSpriteLoaded4)
                {
                    Person.sprite = PersSprite[0];
                    personSpriteLoaded4 = true;
                }
                break;
        }
    }
    public void ChekProgressB()
    {
        switch (_money)
        {
            case >= 250000000000000:
                if (!backgroundSpriteLoaded1)
                {
                    Backgraund.sprite = BackSprite[3];
                    backgroundSpriteLoaded1 = true;
                }
                break;
            case >= 3000000000:
                if (!backgroundSpriteLoaded2)
                {
                    Backgraund.sprite = BackSprite[2];
                    backgroundSpriteLoaded2 = true;
                }
                break;
            case >= 110000:
                if (!backgroundSpriteLoaded3)
                {
                    Backgraund.sprite = BackSprite[1];
                    backgroundSpriteLoaded3 = true;
                }
                break;
            case >= 100:
                if (!backgroundSpriteLoaded4)
                {
                    Backgraund.sprite = BackSprite[0];
                    backgroundSpriteLoaded4 = true;
                }
                break;
        }
    }

}
