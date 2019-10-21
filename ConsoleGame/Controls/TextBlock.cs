using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.Windows;
using ConsoleGame.Interfaces;

namespace ConsoleGame.Controls
{
    class TextBlock : GameObject, IREnderable
    {
        int x, y, width, height;
        List<TextLine> textBlock;
        List<string> text;
        TextLine lines;

        public TextBlock(int x, int y, int width, int height, List<string> text) : base (x, y, width, height)
        {
            int lineCount = 0;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.text = text;
            textBlock = new List<TextLine>();
            foreach (string oneLine in text)
            {
                lines = new TextLine(x + width / 2 - oneLine.Length/2, y + 2 + lineCount, width, oneLine);
                textBlock.Add(lines);
                lineCount++;
            }
        }

        public override void Render()
        {            
            foreach (TextLine oneLine in textBlock)
            {
                oneLine.Render();
            }
        }
    }
}
