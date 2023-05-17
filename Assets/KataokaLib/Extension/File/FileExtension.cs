using System.IO;

namespace KataokaLib.Extension.File
{
    public static class FileExtension
    {
        /// <summary>
        /// ディレクトリが存在しなければ、ディレクトリを作成する
        /// </summary>
        /// <param name="path">Assets/SimpleScript.cs のようなパスを渡す</param>
        /// <returns>ファイルの情報</returns>
        public static FileStream Create(string path)
        {
            if (!global::System.IO.File.Exists(path))
            {
                return global::System.IO.File.Create(path);
            }

            return null;
        }
    }
}