using System.Collections.Generic;
using System.Linq;

namespace CrossCutingLayer.Dto.Standard
{
    public class ResponseDto
    {
        public Dictionary<string, string> Errors { get; set; }
        public bool IsValid { get => !Errors.Any(); }
        public ResponseDto() 
        {
            Errors = new Dictionary<string, string>();
        }
    }
}