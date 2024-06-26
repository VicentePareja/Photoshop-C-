﻿/*
 * Para usar este código debes instalar "imagesharp"
 * https://docs.sixlabors.com/articles/imagesharp/index.html
 * Instalar esta librería es realmente fácil. Yo usé NuGet que aparece en la barra
 * de abajo en Rider. Luego busqué la librería "SixLabors.ImageSharp" y puse instalar.
 */

using MyPhotoshop;
using MyPhotoshop.Effects;

IPhotoEffect[] availableEffects = new IPhotoEffect[] { new BlackAndWhiteEffect(), new DarkenEffect(), new LightenImage()
 , new RotateEffect(), new ReflexEffect(), new BlurEffect(), new EdgesEffect()};
string folder = "imgs";
Controller.Run(folder, availableEffects);