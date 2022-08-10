#pragma once

using namespace System;
using namespace GigaSpaces::Core;
using namespace GigaSpaces::Core::Metadata;

using namespace GigaSpaces::Core::Metadata;

namespace OrderProcessingUnitCommon {
	ref class Data
	{
	public:

		[SpaceID(AutoGenerate = true)]

		String^ _id;
		String^ _info;

		[SpaceRouting]
		Nullable<int> _type;
		bool _processed;

		Data() {}

		Data(String^ info, Nullable<int> type)
			: _info(info), _type(type), _processed(false) {

		}
	};
}
