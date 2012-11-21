#!/bin/bash

# Build solution using Releasemode


#
# Monodocer info here: http://www.mono-project.com/Generating_Documentation
#

# Use monodocer to convert XML-Comments to Monodoc format and merge them to the current documentation.
mdoc --exceptions=added,asm -i src/Touchdown.Core/bin/Release/TouchdownCore.xml -o doc/MonoDoc

# Create single monodoc file
