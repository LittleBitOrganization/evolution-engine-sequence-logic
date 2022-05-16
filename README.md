# Введение

Модуль позволяет создавать группу условий, и ожидать ивент о выполнении всех условий. 

## Зависимости и требования:
* Unity version: 2021.1.6f1 и выше
* Api compatibility level: .Net 4.x
* [Core module](https://github.com/LittleBitOrganization/evolution-engine-core) версии 1.2.0 или выше

## Импорт
```JSON
"dependencies": {
    "com.littlebitgames.sequencelogic": "https://github.com/LittleBitOrganization/evolution-engine-sequence-logic.git",
}
```

## Базовый компонент

* UnitLogic - базовый абстрактный компонет для создания условия. Все объекты являются потомками этого компонента.

## Логические компоненты

* DirectLogic - самый простой логический компонент. В конструкторе принимает условие, которое напрямую влияет на SequenceLogic. Можно изменить значение после инициализации вызвав метод SetValue(condition)

```C#
var directLogicComponent = new DirectLogic(false)

directLogicComponent.OnChangeAvailable += value =>
{
    Debug.Log("Condition is: " + value);
}; 

directLogicComponent.SetValue(true);
```

* ResourceLogic - ожидает количество ресурсов в IDataStorageService по ключу большее или равное значению, переданному в конструкторе

```C#
var resourceLogicComponent = new ResourceLogic(_dataStorageService, resourceKey, resourceValue)

resourceLogicComponent.OnChangeAvailable += value =>
{
    Debug.Log("Condition is: " + value);
}; 
```

Вы можете создать любой логический компонент, унаследовав его от UnitLogic

## Последовательность

SequenceLogic - объект последовательности подписывается на все объекты UnitLogiс. Наследуется от UnitLogic. 

Служит контейнером для объектов UnitLogic

```C#

var sequenceLogic = new SequenceLogic();
sequenceLogic.Add(directLogicComponent)
sequenceLogic.Add(resourceLogicComponent)

//...

sequenceLogic.OnChangeAvailable += value =>
{
    Debug.Log("Condition is: " + value);
}; 

```



Изменение состояния любого компонента, добавленого в SequenceLogic вызывает проверку всех компонентов последовательности и вызывает ивент OnChangeAvailable.
Если все компонетны IsAvaliable == true, то сработает ивент OnChangeAvaliable с параметром true, во всех остальных случаях с параметром false.

В некоторых случаях требуется сделать первую проверку SequenceLogic, т.к. OnChangeAvailable вызовется только при первом обновлении любого компонента.
Для этого используйте метод Check(condition = false)

```C#
sequenceLogic.Check(true);
```

Вы также можете добавлять SequenceLogic в другой SequenceLogic, как и обычный компонент методом Add()





