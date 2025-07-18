[![en](https://img.shields.io/badge/lang-en-red.svg)](README.md)
[![ru](https://img.shields.io/badge/lang-ru-yellow.svg)](README.ru-RU.md)

<h1 align="center">MVP Passive View пример кода</h1>

# Описание

Необходимо сделать калькулятор, в котором поддерживается только одна математическая операция – сложение. Результаты вычислений и состояние
приложения сохраняется между сессиями (сеансами) приложения – нужно хранить и отображать историю вычислений, состояние ввода.

# Особенности

*   Поддерживаемые арифметические операции - сложение. В случае, если пользователь вводит что-то кроме чисел и знака «+», в результат выводить сообщение «Error». Примеры правильных выражений: 54+21, 45+00.
*   Сохранение состояния приложения между сеансами. Когда пользователь закрывает приложение, нужно сохранять его состояние, в данном случае - введенное пользователем выражение, историю вычислений.

# Требования

* Clean Architecture
* Model View Presenter
* Модульность (Assembly Definition)

## Результат

<p align="center">
  <img src="result.gif" alt="Example">
</p>

📱 [APK](Result.apk)

## Модульность

Приложение разделено на 3 основных модуля: Core, Runtime, UI.
* Core - сердце бизнес логики.
* Runtime - связывает бизнес логику и UI.
* UI - все, что связано с отображением и пользовательским вводом.

Сохранение и загрузка данных выполняется в классе `CalculationHistory.cs`. Данные сохраняются в формате json, для работы с Json используется библиотека `Newtonsoft.Json`.

## Стек:
* **Unity 6**
* **Newtonsoft.Json**
