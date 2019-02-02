# XSel
UI Test Wrapper for Selenium
## Description 
This is a small wrapper for Selenium that has some methods you can use in your 
Azure Pipelines. It uses NUnit as the test framework because it hast a method to upload sceernshots to the test results.

## Features
1. Load Chromedriver from the configured location on hosted build agents
2. Take screenhots
3. Wait for DOM ready
4. Set Window size
5. Emulate mobile devices 

## Build status
![Build Status](https://dev.azure.com/wulfland/mkaufmann/_apis/build/status/wulfland.XSel?api-version=5.0-preview.1)
