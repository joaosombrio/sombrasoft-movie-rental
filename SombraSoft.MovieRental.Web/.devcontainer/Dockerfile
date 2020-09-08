#-------------------------------------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See https://go.microsoft.com/fwlink/?linkid=2090316 for license information.
#-------------------------------------------------------------------------------------------------------------

# To fully customize the contents of this image, use the following Dockerfile instead:
# https://github.com/microsoft/vscode-dev-containers/tree/v0.112.0/containers/javascript-node-12/.devcontainer/Dockerfile
FROM node:alpine

# The image referenced above includes a non-root user with sudo access. Add
# the "remoteUser" property to devcontainer.json to use it. On Linux, the container
# user's GID/UIDs will be updated to match your local UID/GID when using the image
# or dockerFile property. Update USER_UID/USER_GID below if you are using the
# dockerComposeFile property or want the image itself to start with different ID
# values. See https://aka.ms/vscode-remote/containers/non-root-user for details.
ARG USER_UID=1000
ARG USER_GID=$USER_UID
ARG USERNAME=node

# [Optional] Update UID/GID if needed
RUN if [ "$USER_GID" != "1000" ] || [ "$USER_UID" != "1000" ]; then \
        groupmod --gid $USER_GID $USERNAME \
        && usermod --uid $USER_UID --gid $USER_GID $USERNAME \
        && chown -R $USER_UID:$USER_GID /home/$USERNAME; \
    fi

RUN apk update
RUN apk upgrade
RUN apk add git
RUN apk add zsh
RUN apk add openssh-client
RUN sh -c "$(wget -O- https://raw.githubusercontent.com/deluan/zsh-in-docker/master/zsh-in-docker.sh)" -- \
    -t agnoster \
    -p git \
    -p ssh-agent \
    -p https://github.com/zsh-users/zsh-autosuggestions \
    -p https://github.com/zsh-users/zsh-completions \
    -p https://github.com/zsh-users/zsh-history-substring-search
RUN npm install -g @angular/cli
RUN npm install

ENV SHELL /bin/zsh