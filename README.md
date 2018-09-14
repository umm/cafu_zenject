# CAFU Zenject

## What

* Zenject utilities for CAFU
* Provide injection for UniRx.MessageBroker
    * Bind `IMessagePublisher` to `MessageBroker`
    * Bind `IMessageReceiver` to `MessageBroker`
* Provide interfaces and extensions to publish/receive some instance
    * `IInstancePublisher`
    * `IInstanceReceiver`

## Requirement

* UniRx
* Zenject
* CAFU v3

## Install

```shell
yarn add "umm/cafu_zenject#^1.0.0"
```

## Usage

### Installationn

Add `CAFUInstaller.prefab` into `Prefab Installers` of Scene Context in System scene.

<img src="https://user-images.githubusercontent.com/838945/45548005-b13f8700-b85d-11e8-8b16-f3a4592dd1e4.png" width="50%" />

### Brokerage instances

If you want to exchange instances generated dynamically, you can use wrapper of `UniRx.MessageBroker`.

#### Publish instance

Implements `IInstancePublisher` and call `this.Publish()` to notify and publish instance.

```csharp
using System;
using CAFU.Zenject.Utility;
using UniRx;
using UnityEngine;
using Zenject;

public class Foo : MonoBehaviour,
    IInstancePublisher
{
    [Inject] IMessagePublisher IInstancePublisher.MessagePublisher { get; }

    private void Start()
    {
        // Notify self instance
        this.Publish();
    }
}
```

#### Receive instance

Implements `IInstanceReceiver` and call `this.Receive<T>()` to receive published instance.

```csharp
using System;
using CAFU.Zenject.Utility;
using UniRx;
using Zenject;

public class Bar :
    IInitializable,
    IInstanceReceiver
{
    [Inject] IMessageReceiver IInstanceReceiver.MessageReceiver { get; }

    void IInitializable.Initialize()
    {
        // Receive instance when created
        this.Receive<Foo>()
            .Subscribe(/* Do something */);
    }
}
```

## License

Copyright (c) 2018 Tetsuya Mori

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)

