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
	public class AlbumService : IAlbumService
	{

		#region 属性声明

		IAlbumRepository AlbumRepository;

		#endregion

		#region	构造函数
		public AlbumService(IAlbumRepository albumRepository)
		{
			AlbumRepository = albumRepository;
		}
		#endregion


		#region 相册操作

		//创建相册
		public Message CreateAlbum(Album album)
		{
			var msg = new Message((int)MessageCode.OK, MessageCode.OK.GetDescription());

			if (album == null)
			{
				msg.Code = (int)MessageCode.DATA_NOT_EMPTY;
				msg.Msg = MessageCode.DATA_NOT_EMPTY.GetDescription();
				return msg;
			}
			var addState = AlbumRepository.CreateAlbum(album);
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

		//取全部相册
		public IEnumerable<Album> GetAlubums()
		{
			var albums = AlbumRepository.GetAlubums();
			return albums;
		}

		//通过ID取相册
		public Album GetAlbumByID(int id)
		{
			return AlbumRepository.GetAlbumByID(id);
		}

		//通过用户ID取相册
		public IEnumerable<Album> GetAlbumsByUserID(int userID)
		{
			return AlbumRepository.GetAlbumsByUserID(userID);
		}

		//删除相册
		public Message DeleteAlbumByID(int id)
		{
			var msg = new Message((int)MessageCode.OK, MessageCode.OK.GetDescription());

			var upState = AlbumRepository.DeleteAlbumByID(id);
			if (upState)
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


		#endregion
	}
}
