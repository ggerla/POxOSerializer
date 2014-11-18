/*
 * Copyright 2014 Giuseppe Gerla. All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.google.devtools.poxoserializer.serializers;

import com.google.devtools.poxoserializer.exception.POxOSerializerException;
import com.google.devtools.poxoserializer.io.POxOPrimitiveDecoder;
import com.google.devtools.poxoserializer.io.POxOPrimitiveEncoder;

import java.util.ArrayList;
import java.util.List;

public class ListSerializer extends GenericClassSerializer {

  public ListSerializer() {
    super(true);
  }

  @Override
  public void write(POxOPrimitiveEncoder encoder, ObjectSerializer serializer, Object value)
    throws POxOSerializerException {
    List<Object> list;
    list = (List<Object>) value;
    if (canBeNull) {
      if (list == null) {
        encoder.write(0x00);
        return;
      } else {
        encoder.write(0x01);
      }
    }
    encoder.writeVarInt(list.size(), true);
    for (Object o : list) {
      serializer.write(encoder, serializer, o);
    }
  }

  @Override
  public Object read(POxOPrimitiveDecoder decoder, ObjectSerializer serializer)
    throws POxOSerializerException {
    if (canBeNull) {
      byte isNull = decoder.readByte();
      if (isNull == 0x00) {
        return null;
      }
    }
    int size = decoder.readVarInt(true);

    List<Object> list = new ArrayList<Object>();

    for (int i = 0; i < size; i++) {
      Object o = serializer.read(decoder, serializer);
      list.add(o);
    }

    return list;
  }
}
