using System.Threading.Tasks;
using BlazorInputFile;

namespace BookStore_UI.Contracts
{
    public interface IFileUpload
    {
        public Task UploadFile(IFileListEntry file, string picName);
        public void RemoveFile(string picName);
    }
}
