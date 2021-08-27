# TDocumentGeneration

[![Build Status](https://app.travis-ci.com/nusreta/TDocumentGeneration.svg?branch=main)](https://app.travis-ci.com/nusreta/TDocumentGeneration)
[![NuGet Version and Downloads count](https://buildstats.info/nuget/TDocumentGeneration)](https://www.nuget.org/packages/TDocumentGeneration)


 ``` Aspose.Words v21.8.0 ``` ``` Aspose.BarCode v21.7.0 ```


The package contains helpers for generating template based PDF documents with Aspose.
It provides possibility to fill out the template by replacing placeholders with values, to create bar codes and to create tables with dynamic number of rows.


## Prerequisites

Before using the generator, ```Word``` template should be ready. 
Template can contain static text and it would be the same and it will repeat in all created documents based on the template, 
and dynamic text that can be different for each document.
Placeholders in the template can be defined by surounding the placeholder name with ```::```.
For example, placeholder ```::FirstAndLastName::``` in the template would be replaced with the actual name ```John Doe``` when document is generated.
To import a bar code, we should insert a bookmark in the template and place the bookmark where we want the bar code to be.
To import a table, we should define a table header in the template and create a new bookmark in the template placed over the header.

## Usage



### How to set Aspose licence
### How to set template path and document's destination path
### How to fill out placeholders in the template
### How to create a bar code
### How to create a table

## Licence

[Apache-2.0](https://choosealicense.com/licenses/apache-2.0/)

## Releases

### Previous

### Latest
- v1.0.0 - contains simple template based ```PDF``` generator 

### Planned
- add possibility to adjust format of table cells and bar code layout

 

