﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.DataAccess.DataTransferObjects.ContentDTOs
{
    public class ChatDTO
    {
        // All the data for a message
        public string MessageContent {
            get
            {
                return MessageContent;
            }
            set
            {
                MessageContent = value;
            }
        }
    }
}