﻿#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010 FUJIWARA, Yusuke
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
#endregion -- License Terms --

using System;

namespace MsgPack
{
	internal static class MessagePackCode
	{
		public const int NilValue = 0xc0;
		public const int TrueValue = 0xc3;
		public const int FalseValue = 0xc2;
		public const int SignedInt8 = 0xd0;
		public const int UnsignedInt8 = 0xcc;
		public const int SignedInt16 = 0xd1;
		public const int UnsignedInt16 = 0xcd;
		public const int SignedInt32 = 0xd2;
		public const int UnsignedInt32 = 0xce;
		public const int SignedInt64 = 0xd3;
		public const int UnsignedInt64 = 0xcf;
		public const int Real32 = 0xca;
		public const int Real64 = 0xcb;
		public const int MinimumFixedArray = 0x90;
		public const int MaximumFixedArray = 0x9f;
		public const int Array16 = 0xdc;
		public const int Array32 = 0xdd;
		public const int MinimumFixedMap = 0x80;
		public const int MaximumFixedMap = 0x8f;
		public const int Map16 = 0xde;
		public const int Map32 = 0xdf;
		public const int MinimumFixedRaw = 0xa0;
		public const int MaximumFixedRaw = 0xbf;
		public const int Raw16 = 0xda;
		public const int Raw32 = 0xdb;
	}
}
