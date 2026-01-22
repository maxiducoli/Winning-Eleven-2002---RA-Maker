# Winning Eleven 2002 - RA Maker V0.1 alpha - Obsoleta

🎙️ *Herramienta en C# para crear bancos de audio personalizados (.RA) con relatos y comentarios para Winning Eleven 2002 (PC).*

Este proyecto permite generar archivos **`.RA`**, que son contenedores utilizados por *Winning Eleven 2002* para reproducir **comentarios en vivo, narraciones y frases contextuales** durante los partidos. Internamente, estos archivos empaquetan múltiples clips de audio en formato **VAG** (el estándar de compresión ADPCM usado originalmente en PlayStation y adaptado en la versión PC del juego).

Desarrollado en **C#**, este utilitario nace de mi pasión por el modding desde principios de los 2000 —cuando, bajo el pseudónimo **CARP**, comencé a modificar juegos como *Winning Eleven* para personalizar cada detalle... incluso la voz del comentarista.

---

## 🎧 ¿Qué hace esta herramienta?

- Permite seleccionar varios archivos de audio previamente convertidos a formato **`.VAG`**.
- Los organiza según el índice interno esperado por el juego.
- Genera un único archivo **`.RA`** compatible con *Winning Eleven 2002*.
- Facilita la creación de packs de audio personalizados: ¡comentarios en castellano, frases únicas, e incluso narraciones completas!

> 🔧 **Requisito previo**: Los clips de audio deben estar en formato VAG (mono, 22.05 kHz, ADPCM). Puedes usar herramientas como **VAGTool**, **Sony’s VAG Conv** o scripts personalizados para convertirlos desde WAV.

---

## 💻 Tecnología

- **Lenguaje**: C#  
- **Framework**: .NET Framework (versión compatible con Windows Forms)  
- **Interfaz**: Aplicación de escritorio (Windows)  
- **Tipo**: Utilidad de modding / conversión de assets

---

## 📦 Estado del proyecto

Este repositorio es **histórico y funcional**. Aunque fue creado con fines personales, puede servir como referencia para:
- Entender formatos de audio en juegos retro
- Aprender sobre serialización binaria en C#
- Inspirar nuevas herramientas de modding para títulos clásicos

---

## 🧠 Un poco de historia

> *"Quería escuchar ‘¡Gooooool!’ en castellano cuando anotaba... así que aprendí cómo funcionaba el sistema de audio del juego y construí esta herramienta."*

Este proyecto simboliza el puente entre mi curiosidad de jugador y mi identidad como programador. Hoy trabajo con ASP.NET Core, Unity y patrones modernos, pero nunca olvido que todo empezó con ganas de cambiar una voz en un juego de fútbol.

---

## 📜 Licencia

Uso permitido con fines **no comerciales**. Si reutilizás el código, por favor citá a **Maximiliano Ducoli (CARP)** como autor original.

---

🎮 ¡Dale voz a tus partidos con tu propia narración!
