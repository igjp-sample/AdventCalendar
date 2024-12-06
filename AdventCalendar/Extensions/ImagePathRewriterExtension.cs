using Markdig;
using Markdig.Renderers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

public class ImagePathRewriterExtension : IMarkdownExtension
{
    public void Setup(MarkdownPipelineBuilder pipeline) { }

    public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer) { }

    public static void RewriteImagePaths(MarkdownDocument document)
    {
        // Markdownのノードを走査して画像のパスを変更する
        foreach (var node in document.Descendants<LinkInline>())
        {
            if (node.IsImage && node.Url != null)
            {
                // 画像のURLを書き換える処理
                node.Url = "https://github.com/igjp-sample/AdventCalendar/blob/main/content/" + node.Url + "?raw=true";
            }
        }
    }
}