﻿using DiscussClassSystem.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xmuer.Common.Infrastructure;
using xmuer.Entities.Home;
using xmuer.Mapper.Interface;
using xmuer.Service.Interface;

namespace xmuer.Service.Implement
{
	public class PhotoService : IPhotoService
	{
		#region 属性声明

		IPhotoRepository PhotoRepository;

		#endregion

		#region	构造函数
		public PhotoService(IPhotoRepository photoRepository)
		{
			PhotoRepository = photoRepository;
		}
		#endregion

		#region 照片操作

		//创建照片
		public Message CreatePhoto(Photo photo)
		{
			var msg = new Message((int)MessageCode.OK, MessageCode.OK.GetDescription());

			if (photo == null)
			{
				msg.Code = (int)MessageCode.DATA_NOT_EMPTY;
				msg.Msg = MessageCode.DATA_NOT_EMPTY.GetDescription();
				return msg;
			}
			var addState = PhotoRepository.CreatePhoto(photo);
			if (addState)
			{
				msg.Code = (int)MessageCode.OK;
				msg.Msg = MessageCode.OK.GetDescription();
			}
			else
			{
				msg.Code = (int)MessageCode.INTERNAL_SERVER_ERR;
				msg.Msg = MessageCode.INTERNAL_SERVER_ERR.GetDescription();
			}
			return msg;
		}

		//通过相册ID取照片
		public IEnumerable<Photo> GetPhotosByAlbumID(int albumID)
		{
			return PhotoRepository.GetPhotosByAlbumID(albumID);
		}


		#endregion
	}
}
