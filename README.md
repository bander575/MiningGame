# Mining Game 🏔️⛏️

محاكاة لعبة حفر المنجم على Unity

## وصف اللعبة

لعبة محاكاة تفاعلية حيث يقوم اللاعب بحفر المنجم وتجميع الموارد المختلفة (الذهب، الفضة، الماس، إلخ) وبيعها لكسب الأموال. باستخدام الأموال المكتسبة، يمكن تطوير الأدوات والمعدات لحفر أعمق والحصول على موارد أفضل.

## المميزات الأساسية

✅ **التنقيب والحفر** - استخدم الأدوات لحفر الموارد من المنجم
✅ **تجميع الموارد** - اجمع أنواع مختلفة من الموارد القيمة
✅ **بيع الموارد** - بع الموارد وكسب الأموال
✅ **متجر التطوير** - قم بترقية أدواتك وتحسين أدائك
✅ **حفظ اللعبة** - احفظ تقدمك واستمر لاحقاً

## البنية الأساسية للمشروع

```
Assets/
├── Scripts/
│   ├── Managers/
│   │   ├── GameManager.cs
│   │   ├── ResourceManager.cs
│   │   └── SaveSystem.cs
│   ├── Player/
│   │   ├── PlayerController.cs
│   │   └── MiningTool.cs
│   ├── Mining/
│   │   ├── MineResource.cs
│   │   └── MiningSystem.cs
│   ├── Shop/
│   │   ├── Shop.cs
│   │   └── ToolUpgrade.cs
│   └── UI/
│       ├── UIManager.cs
│       ├── ResourceDisplay.cs
│       └── ShopUI.cs
├── Prefabs/
├── Scenes/
└── Resources/
```

## المتطلبات

- Unity 2021.3 LTS أو أحدث
- C#

## التثبيت والبدء

1. استنساخ المستودع:
```bash
git clone https://github.com/bander575/MiningGame.git
```

2. فتح المشروع في Unity

3. فتح المشهد الرئيسي: `Assets/Scenes/MainScene.unity`

4. الضغط على Play للبدء

## الترخيص

MIT License

---

تم إنشاؤه بواسطة: bander575 🎮
